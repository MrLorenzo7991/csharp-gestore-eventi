using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Conferenza : Evento
    {
        private string relatore;
        private double prezzo;
        public Conferenza(string titolo, DateTime dataEvento, int capienzaMassimaEvento, string relatore, double prezzo) : base(titolo, dataEvento, capienzaMassimaEvento)
        {
            this.relatore = relatore;
            this.prezzo = prezzo;   
        }

        //getter
        public string GetRelatore()
        {
            return relatore;
        }
        public double GetPrezzo()
        {
            return prezzo;
        }
        //setter
        public void SetRelatore(string nuovoRelatore)
        {
            relatore = nuovoRelatore;
        }
        public void SetPrezzo(double nuovoPrezzo)
        {
            prezzo = nuovoPrezzo;
        }

        //override ToString()
        public override string ToString()
        {
            string dettagliConferenza = base.dataEvento.ToString() + " - Intervento di " + relatore + " - " + prezzo.ToString("0.00");
            return dettagliConferenza;
        }
    }
}
