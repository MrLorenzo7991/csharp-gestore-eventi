using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
