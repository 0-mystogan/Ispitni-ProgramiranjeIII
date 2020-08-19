using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpIntroWinForms.IB170208
{
    class Ocjene
    {
        public int Id { get; set; }
        public int Vrijednost { get; set; }

        public override string ToString()
        {
            return Vrijednost.ToString();
        }
    }
}
