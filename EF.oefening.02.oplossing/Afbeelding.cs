using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.oefening._02.oplossing
{
    internal class Afbeelding
    {
        private string Pad = "";
        private string Beschrijving = "";

        public Afbeelding(string pad)
        {
            Pad = pad;
        }

        public Afbeelding(string pad, string beschrijving)
        {
            Pad = pad;
            Beschrijving = beschrijving;
        }

        public void Bijschrift(string beschrijving)
        {
            Beschrijving = beschrijving;
        }

        public string AfbPad()
        {
            return Pad;
        }

        public string TekstBijschrift()
        {
            return Beschrijving;
        }

        public override string ToString()
        {
            string bestand = Pad.Split("\\").Last();
            return $"{bestand} | {Beschrijving}";
        }
    }
}
