using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_VB2018
{
    class VB2018
    {
        //varos;nev1;nev2;ferohely
        public string Varos;
        public string Nev1;
        public string Nev2;
        public int Ferohely;

        public VB2018(string sor)
        {
            var dbok = sor.Split(';');
            this.Varos = dbok[0];
            this.Nev1 = dbok[1];
            this.Nev2 = dbok[2];
            this.Ferohely = int.Parse(dbok[3]);
        }
    }
}
