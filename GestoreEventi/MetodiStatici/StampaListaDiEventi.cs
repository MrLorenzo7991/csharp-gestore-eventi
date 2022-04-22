using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi.MetodiStatici
{
    internal static class StampaListaDiEventi
    {
        public static void StampaLista(List<Evento> listaDaStampare)
        {
            foreach(Evento evento in listaDaStampare)
            {
                evento.ToString();
            }
        }
    }
}
