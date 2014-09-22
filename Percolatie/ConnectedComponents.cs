using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Percolatie
{
    static class ConnectedComponents
    {
        public static void MaakConnectedComponent(int veldNr, int aantalRijen, int aantalKolommen, int[] ouderId, int[] grootte)
        {
            int bovenkant = aantalRijen * aantalKolommen;
            int onderkant = bovenkant + 1;
            // bovenkant
            if (veldNr / aantalKolommen == 0)
                samenVoegen(veldNr, bovenkant, ouderId, grootte); // verbinden met virtuele bovenkant
            else if (ouderId[veldNr - aantalKolommen] >= 0)
                samenVoegen(veldNr, veldNr - aantalKolommen, ouderId, grootte);
            // onderkant
            if (veldNr / aantalKolommen == aantalRijen - 1)
                samenVoegen(veldNr, onderkant, ouderId, grootte); // verbinden met virtuele onderkant
            else if (ouderId[veldNr + aantalKolommen] >= 0)
                samenVoegen(veldNr, veldNr + aantalKolommen, ouderId, grootte);
            // linkerkant
            if (veldNr % aantalKolommen > 0 && ouderId[veldNr - 1] >= 0)
                samenVoegen(veldNr, veldNr - 1, ouderId, grootte);
            // rechterkant
            if (veldNr % aantalKolommen < aantalKolommen - 1 && ouderId[veldNr + 1] >= 0)
                samenVoegen(veldNr, veldNr + 1, ouderId, grootte);
        }

        public static bool InZelfdeComponent(int veld1, int veld2, int[] ouderId)
        {
            return vindWortel(veld1, ouderId) == vindWortel(veld2, ouderId);
        }

        static int vindWortel(int veldNr, int[] ouderId)
        {
            int wortel = veldNr;
            while (wortel != ouderId[wortel]) // wortel zoeken
                wortel = ouderId[wortel];
            while (veldNr != ouderId[veldNr]) // padcompressie uitvoeren
            {
                int ouder = ouderId[veldNr];
                ouderId[veldNr] = wortel;
                veldNr = ouder;
            }
            return wortel;
        }

        static void samenVoegen(int veld1, int veld2, int[] ouderId, int[] grootte)
        {
            int wortel1 = vindWortel(veld1, ouderId);
            int wortel2 = vindWortel(veld2, ouderId);
            if (wortel1 == wortel2)
                return;

            if (grootte[wortel1] <= grootte[wortel2])
            {
                ouderId[wortel1] = wortel2;
                grootte[wortel2] = grootte[wortel1] + grootte[wortel2];
            }
            else
            {
                ouderId[wortel2] = wortel1;
                grootte[wortel1] = grootte[wortel1] + grootte[wortel2];
            }
        }
    }
}
