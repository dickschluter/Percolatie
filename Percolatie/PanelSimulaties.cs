using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Percolatie
{
    public partial class PanelSimulaties : UserControl
    {
        Action doeSimulaties;
        CancellationTokenSource cancellationTokenSource; // voor onderbreken simulaties
        Bitmap bitmapLegeGrafiek;
        
        public PanelSimulaties()
        {
            InitializeComponent();

            doeSimulaties = () =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                cancellationTokenSource = new CancellationTokenSource();

                // simulaties uitvoeren
                int aantalSimulaties = 1000;
                int aantalRijen = (int)numericUpDownRijen.Value;
                int aantalKolommen = (int)numericUpDownKolommen.Value;
                double[] proporties = checkBoxParallel.Checked ?
                    Simulaties.Asynchroon(aantalSimulaties, aantalRijen, aantalKolommen, cancellationTokenSource) :
                    Simulaties.Synchroon(aantalSimulaties, aantalRijen, aantalKolommen, cancellationTokenSource);

                // resultaten accumuleren en rapporteren
                double proportieCumulatief = 0.0;
                double proportieKwadraatCumulatief = 0.0;
                int[] aantalPerProportieInterval = new int[200];
                for (int n = 0; n < aantalSimulaties; n++)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        stopwatch.Stop();
                        updateTextBoxSimulatieAsync("Simulatie afgebroken");
                        enableButtonStartSimulatieAsync();
                        return;
                    }

                    double proportie = proporties[n];
                    proportieCumulatief += proportie;
                    proportieKwadraatCumulatief += proportie * proportie;
                    int proportieInterval = (int)(200 * proportie + 0.5);
                    aantalPerProportieInterval[proportieInterval]++;
                    updateTextBoxSimulatieAsync(string.Format("{0}. proportie = {1}", n + 1, Math.Round(proportie, 5)) + Environment.NewLine);
                }

                // eindresultaat rapporteren
                double gemiddeldeProportie = proportieCumulatief / aantalSimulaties;
                double kwadratenSom = proportieKwadraatCumulatief - proportieCumulatief * proportieCumulatief / aantalSimulaties;
                double standaardDeviatie = Math.Sqrt(kwadratenSom / (aantalSimulaties - 1));

                updateTextBoxSimulatieAsync(Environment.NewLine + string.Format("1000 trials met een {0} x {1} matrix", aantalRijen, aantalKolommen));
                updateTextBoxSimulatieAsync(Environment.NewLine + string.Format("Gemiddelde proportie = {0}", Math.Round(gemiddeldeProportie, 5)));
                updateTextBoxSimulatieAsync(Environment.NewLine + string.Format("Standaarddeviatie = {0}", Math.Round(standaardDeviatie, 5)));

                int xMediaan;
                updatePictureBoxSimulatieAsync(maakBitmapGrafiek(aantalPerProportieInterval, out xMediaan));
                updateLabelMediaanAsync(xMediaan);

                enableButtonStartSimulatieAsync();
                stopwatch.Stop();
                updateTextBoxSimulatieAsync(Environment.NewLine + string.Format("Verstreken tijd = {0} seconden", Math.Round(stopwatch.ElapsedMilliseconds / 1000.0, 1)));
            };

            bitmapLegeGrafiek = new Bitmap(pictureBoxGrafiek.Width, pictureBoxGrafiek.Height);
            using (Graphics g = Graphics.FromImage(bitmapLegeGrafiek))
            {
                g.Clear(Color.White);
                g.DrawLine(Pens.LightGray, 0, 50, 200, 50);
            }
            pictureBoxGrafiek.Image = bitmapLegeGrafiek;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            textBoxSimulatie.Text = string.Format("1000 trials met een {0} x {1} matrix{3}{2} uitvoering{3}{3}",
                numericUpDownRijen.Value, numericUpDownKolommen.Value, (checkBoxParallel.Checked ? "Parallelle" : "Seriele"), Environment.NewLine);
            pictureBoxGrafiek.Image = bitmapLegeGrafiek;
            labelMediaan.Text = string.Empty;

            Task taak = Task.Factory.StartNew(doeSimulaties); // asynchroon uitvoeren om animatie niet te onderbreken
            buttonStop.Focus(); // activeren UI versnelt de updateAsync methoden
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
                cancellationTokenSource.Cancel();
        }

        private Bitmap maakBitmapGrafiek(int[] aantalPerProportieInterval, out int xMediaan)
        {
            int cumulatief = 0;
            int x = 0;
            for (int i = 1; i < 200; i++) // aantallen accumuleren
            {
                cumulatief += aantalPerProportieInterval[i];
                aantalPerProportieInterval[i] = cumulatief;
                if (cumulatief <= 500)
                    x++;
            }

            Bitmap bitmapGrafiek = new Bitmap(bitmapLegeGrafiek);
            using (Graphics g = Graphics.FromImage(bitmapGrafiek))
            {
                g.DrawLine(Pens.LightGray, x, 0, x, 100);
                for (int i = 1; i < 200; i++)
                {
                    int y1 = 100 - aantalPerProportieInterval[i - 1] / 10;
                    int y2 = 100 - aantalPerProportieInterval[i] / 10;
                    g.DrawLine(Pens.Black, i - 1, y1, i, y2);
                }
            }

            xMediaan = x;
            return bitmapGrafiek;
        }

        void updateTextBoxSimulatieAsync(string tekst)
        {
            textBoxSimulatie.Invoke(new MethodInvoker(() => textBoxSimulatie.AppendText(tekst)));
        }

        void updatePictureBoxSimulatieAsync(Bitmap bitmap)
        {
            pictureBoxGrafiek.Invoke(new MethodInvoker(() => pictureBoxGrafiek.Image = bitmap));
        }

        void updateLabelMediaanAsync(int xMediaan)
        {
            labelMediaan.Invoke(new MethodInvoker(() =>
            {
                labelMediaan.Text = Math.Round((double)xMediaan / 200, 2).ToString();
                labelMediaan.Location = new Point(100 + xMediaan - labelMediaan.Width / 2, 626);
            }));
        }

        void enableButtonStartSimulatieAsync()
        {
            buttonStart.Invoke(new MethodInvoker(() => buttonStart.Enabled = true));
        }
    }
}
