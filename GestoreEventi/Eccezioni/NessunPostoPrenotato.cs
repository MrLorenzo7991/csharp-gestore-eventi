using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi.Eccezioni
{
    internal class NessunPostoPrenotato : Exception
    {
        public NessunPostoPrenotato(string messaggio) : base(messaggio)
        {

        }
    }
}
