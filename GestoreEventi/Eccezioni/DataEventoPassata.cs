using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi.Eccezioni
{
    internal class DataEventoPassata : Exception
    {
        public DataEventoPassata(string messaggio) : base(messaggio)
        { 
        
        }
    }
}
