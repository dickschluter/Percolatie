using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Percolatie
{
    public partial class Form1 : Form
    {
        Random random;
        List<Panel> lijstVelden = new List<Panel>();
        List<int> zwarteVelden = new List<int>();

        int aantalRijen = 10, aantalVelden = 100;
        int bovenkant = 100, onderkant = 101;
        // arrays bevatten 2 extra velden: [aantalVelden] is bovenkant, [aantalVelden + 1] is onderkant
        int[] ouderId; // ouder in de boom, -1 als veld zwart is
        int[] grootte; // aantal elementen in de boom onder deze wortel

        PanelSimulaties panelSimulaties;

        public Form1()
        {
            InitializeComponent();

            for (int rij = 0; rij < 10; rij++)
                for (int kolom = 0; kolom < 10; kolom++)
                {
                    Panel panelVeld = new Panel();
                    panelVeld.Size = new Size(40, 40);
                    panelVeld.Location = new Point(kolom * 40, rij * 40);
                    panelVeld.BackColor = Color.FromArgb(40, 40, 40);
                    panelVeld.BorderStyle = BorderStyle.FixedSingle;
                    lijstVelden.Add(panelVeld);
                    panelAnimatie.Controls.Add(panelVeld);
                }

            panelSimulaties = new PanelSimulaties();
            panelSimulaties.Location = new Point(500, 0);
            Controls.Add(panelSimulaties);
        }

        private void numericUpDownAantalRijen_ValueChanged(object sender, EventArgs e)
        {
            foreach (Panel panel in lijstVelden)
                panel.Dispose();
            lijstVelden.Clear();

            aantalRijen = (int)numericUpDownAantalRijen.Value;
            aantalVelden = aantalRijen * aantalRijen;
            bovenkant = aantalVelden;
            onderkant = bovenkant + 1;
            int afm = 400 / aantalRijen;
            for (int rij = 0; rij < aantalRijen; rij++)
                for (int kolom = 0; kolom < aantalRijen; kolom++)
                {
                    Panel panelVeld = new Panel();
                    panelVeld.Size = new Size(afm, afm);
                    panelVeld.Location = new Point(kolom * afm, rij * afm);
                    panelVeld.BackColor = Color.FromArgb(40, 40, 40);
                    panelVeld.BorderStyle = BorderStyle.FixedSingle;
                    lijstVelden.Add(panelVeld);
                    panelAnimatie.Controls.Add(panelVeld);
                }

            labelN.Text = "N = 0";
            labelPercolatie.Text = "";
        }

        private void buttonStartAnimatie_Click(object sender, EventArgs e)
        {
            random = new Random();
            zwarteVelden.Clear();
            for (int i = 0; i < aantalVelden; i++)
            {
                lijstVelden[i].BackColor = Color.FromArgb(40, 40, 40);
                zwarteVelden.Add(i);
            }

            ouderId = new int[aantalVelden + 2];
            grootte = new int[aantalVelden + 2];
            for (int i = 0; i < aantalVelden + 2; i++)
            {
                ouderId[i] = (i < aantalVelden) ? -1 : i;
                grootte[i] = 1;
            }

            numericUpDownAantalRijen.Enabled = false;
            numericUpDownInterval.Enabled = false;
            buttonStartAnimatie.Enabled = false;
            labelN.Text = "N = 0";
            labelPercolatie.Text = "";
            timerAnimatie.Interval = (int)numericUpDownInterval.Value;
            timerAnimatie.Start();
        }

        private void timerAnimatie_Tick(object sender, EventArgs e)
        {
            // random kiezen nieuw wit veld
            int index = random.Next(zwarteVelden.Count);
            int veldNr = zwarteVelden[index];
            zwarteVelden.RemoveAt(index);

            // wit veld invoegen
            labelN.Text = "N = " + (aantalVelden - zwarteVelden.Count).ToString();
            lijstVelden[veldNr].BackColor = Color.White;
            ouderId[veldNr] = veldNr;
            ConnectedComponents.MaakConnectedComponent(veldNr, aantalRijen, aantalRijen, ouderId, grootte);

            // als percolatie optreedt stoppen
            if (ConnectedComponents.InZelfdeComponent(bovenkant, onderkant, ouderId))
            {
                labelPercolatie.Text = "Percolatie bij proportie " + ((double)(aantalVelden - zwarteVelden.Count) / aantalVelden).ToString();
                buttonStopAnimatie_Click(sender, e);
            }
        }

        private void buttonStopAnimatie_Click(object sender, EventArgs e)
        {
            timerAnimatie.Stop();
            numericUpDownAantalRijen.Enabled = true;
            numericUpDownInterval.Enabled = true;
            buttonStartAnimatie.Enabled = true;
        }
    }
}
