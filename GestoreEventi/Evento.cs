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
        private string titolo;
        private DateTime dataEvento;
        private int capienzaMassimaEvento;
        private int numeroPostiPrenotati;

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
        public int GetnumeroPostiPrenotati()
        {
            return numeroPostiPrenotati;
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
        public void Prenota()
        {
            this.numeroPostiPrenotati++;
        }
        public void Disdici()
        {
            if (dataEvento < DateTime.Now)
            {
                throw new DataEventoPassata("Non puoi disdire un posto ad un evento già passato");
            }
            else if(numeroPostiPrenotati <= 0)
            {
                throw new NessunPostoPrenotato("Nessun posto da disdire");
            }
            this.numeroPostiPrenotati--;
        }
        public override string ToString()
        {
            string dataPiuTitoloEvento = dataEvento.ToString("dd/MM/yyyy") +" - "+ titolo;
            return dataPiuTitoloEvento;
        }
    }
}
