using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Percolatie
{
    static class Simulaties
    {
        public static double[] Synchroon(int aantalSimulaties, int aantalRijen, int aantalKolommen, CancellationTokenSource cts)
        {
            int aantalVelden = aantalRijen * aantalKolommen;
            int bovenkant = aantalVelden;
            int onderkant = bovenkant + 1;

            double[] proporties = new double[aantalSimulaties];
            Random seedGenerator = new Random();
            int[] seeds = new int[aantalSimulaties];
            for (int n = 0; n < aantalSimulaties; n++)
                seeds[n] = seedGenerator.Next();

            List<int> zwarteVelden = new List<int>();
            int[] ouderId = new int[aantalVelden + 2];
            int[] grootte = new int[aantalVelden + 2];

            for (int n = 0; n < aantalSimulaties; n++)
            {
                // initialiseren
                Random randomSim = new Random(seeds[n]);
                zwarteVelden.Clear();
                for (int i = 0; i < aantalVelden; i++)
                    zwarteVelden.Add(i);
                for (int i = 0; i < aantalVelden + 2; i++)
                {
                    ouderId[i] = (i < aantalVelden) ? -1 : i;
                    grootte[i] = 1;
                }
                int aantalWit = 0;

                // uitvoeren
                while (ConnectedComponents.InZelfdeComponent(bovenkant, onderkant, ouderId) == false)
                {
                    // random kiezen nieuw wit veld
                    int index = randomSim.Next(zwarteVelden.Count);
                    int veldNr = zwarteVelden[index];
                    zwarteVelden.RemoveAt(index);
                    // wit veld invoegen
                    ouderId[veldNr] = veldNr;
                    ConnectedComponents.MaakConnectedComponent(veldNr, aantalRijen, aantalKolommen, ouderId, grootte);
                    // teller verhogen
                    aantalWit++;
                }
                proporties[n] = (double)aantalWit / aantalVelden;

                if (cts.IsCancellationRequested)
                    break;
            }

            return proporties;
        }

        public static double[] Asynchroon(int aantalSimulaties, int aantalRijen, int aantalKolommen, CancellationTokenSource cts)
        {
            int aantalVelden = aantalRijen * aantalKolommen;
            int bovenkant = aantalVelden;
            int onderkant = bovenkant + 1;

            double[] proporties = new double[aantalSimulaties];
            Random seedGenerator = new Random();
            int[] seeds = new int[aantalSimulaties];
            for (int n = 0; n < aantalSimulaties; n++)
                seeds[n] = seedGenerator.Next();

            ParallelOptions parallelOptions = new ParallelOptions() { CancellationToken = cts.Token };
            try
            {
                Parallel.For(0, aantalSimulaties, parallelOptions, (n) =>
                {
                    // initialiseren
                    Random randomSim = new Random(seeds[n]);
                    List<int> zwarteVelden = new List<int>();
                    int[] ouderId = new int[aantalVelden + 2];
                    int[] grootte = new int[aantalVelden + 2];
                    for (int i = 0; i < aantalVelden; i++)
                        zwarteVelden.Add(i);
                    for (int i = 0; i < aantalVelden + 2; i++)
                    {
                        ouderId[i] = (i < aantalVelden) ? -1 : i;
                        grootte[i] = 1;
                    }
                    int aantalWit = 0;

                    // uitvoeren
                    while (ConnectedComponents.InZelfdeComponent(bovenkant, onderkant, ouderId) == false)
                    {
                        // random kiezen nieuw wit veld
                        int index = randomSim.Next(zwarteVelden.Count);
                        int veldNr = zwarteVelden[index];
                        zwarteVelden.RemoveAt(index);
                        // wit veld invoegen
                        ouderId[veldNr] = veldNr;
                        ConnectedComponents.MaakConnectedComponent(veldNr, aantalRijen, aantalKolommen, ouderId, grootte);
                        // teller verhogen
                        aantalWit++;
                    }
                    proporties[n] = (double)aantalWit / aantalVelden;
                });
            }
            catch (OperationCanceledException) { }

            return proporties;
        }
    }
}
