using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi.Eccezioni
{
    internal class NumeroUgualeOInferioreAZero : Exception
    {
        public NumeroUgualeOInferioreAZero(string messaggio) : base(messaggio)
        {

        }
    }
}
