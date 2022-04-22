using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class ProgrammaEventi
    {
        private string titoloProgramma;
        private List<Evento> eventi;

        public ProgrammaEventi(string titoloProgrammaDiEventi)
        {
            this.titoloProgramma = titoloProgrammaDiEventi;
            this.eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento eventoDaAggiungereAllaLista)
        {
            eventi.Add(eventoDaAggiungereAllaLista);
        }

        public List<Evento> EventiNellaData(DateTime dataEvento)
        {
            List<Evento> eventiStessaData = new List<Evento> ();
            foreach (Evento evento in eventi)
            {
                if(evento.GetDataEvento() == dataEvento)
                {
                    eventiStessaData.Add(evento);
                }                                           //forse aggiungere eccezione se nessun evento ha quella data
            }
            return eventiStessaData;
        }

        public int NumeroEventiLista() //controllare
        {
            return eventi.Count;
        }

        public void SvuotaListaEventi()
        {
            eventi.Clear();
        }

        public string TuttoIlProgramma()
        {
            string tuttoIlProgramma = titoloProgramma + ":\n";
            foreach(Evento evento in eventi)
            {
                tuttoIlProgramma += "\t" + evento.ToString() + "\n";
            }
            return tuttoIlProgramma;
        }
        public static void StampaLista(List<Evento> listaDaStampare)
        {
            foreach (Evento evento in listaDaStampare)
            {
                Console.WriteLine(evento.ToString());
            }
        }
    }
}
