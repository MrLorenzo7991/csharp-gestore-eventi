using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestoreEventi.Eccezioni;

namespace GestoreEventi
{
    internal class Evento
    {
        private protected string titolo;
        private protected DateTime dataEvento;
        private protected int capienzaMassimaEvento;
        private protected int numeroPostiPrenotati;

        public Evento(string titolo, DateTime dataEvento, int capienzaMassimaEvento)
        {
            this.titolo = titolo;
            this.capienzaMassimaEvento = capienzaMassimaEvento;
            this.numeroPostiPrenotati = 0;
            if (dataEvento < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }
            else
            {

                this.dataEvento = dataEvento;
            }
            //forse aggiungere numeroPostiDisponibili
        }

        //Getter
        public string GetTitolo()
        {
            return titolo;
        }
        public DateTime GetDataEvento()
        {
            return dataEvento;
        }
        public int GetCapienzaMassimaEvento()
        {
            return capienzaMassimaEvento;
        }
        public int GetNumeroPostiPrenotati()
        {
            return numeroPostiPrenotati;
        }
        public int GetNumeroPostiDisponibili()
        {
            int numeroPostiDisponibili = capienzaMassimaEvento - numeroPostiPrenotati;      //forse da aggiungere come attributo
            return numeroPostiDisponibili;
        }

        //Setter
        public void SetTitolo(string nuovoTitolo)
        {
            titolo = nuovoTitolo;
        }
        public void SetData(DateTime nuovaData)
        {
            if (nuovaData < DateTime.Now)
            {
                throw new InvalidDataException("La data dell'appuntamento non può essere nel passato");
            }
            else
            {

                this.dataEvento = nuovaData;
            }
        }

        //Metodi
        public void Prenota(int numeroDiPostiDaPrenotare)
        {
            int numeroPostiDisponibili = capienzaMassimaEvento - numeroPostiPrenotati;
            if (numeroDiPostiDaPrenotare <= numeroPostiDisponibili)
            {
                numeroPostiPrenotati += numeroDiPostiDaPrenotare;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Non sono diponibili quel numero di posti");
            }
        }
        public void Disdici(int numeroDiPostiDaDisdire)
        {
            if (dataEvento < DateTime.Now)
            {
                throw new DataEventoPassata("Non puoi disdire un posto ad un evento già passato");
            }
            else if(numeroPostiPrenotati <= 0)
            {
                throw new NessunPostoPrenotato("Nessun posto da disdire");
            }
            else if(numeroDiPostiDaDisdire > capienzaMassimaEvento)
            {
                numeroPostiPrenotati = 0;
            }
            else
            {
                numeroPostiPrenotati -= numeroDiPostiDaDisdire;
            }
        }
        public override string ToString()
        {
            string dataPiuTitoloEvento = dataEvento.ToString("dd/MM/yyyy") +" - "+ titolo;
            return dataPiuTitoloEvento;
        }
    }
}
