using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi.MetodiStatici
{
    internal static class ControlloInput
    {
        public static DateTime ControllaFormatoData(string dataInStringa)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(dataInStringa);
                return dateTime;
            }
            catch (Exception)
            {
                throw new Exception("Formato data non corretto");
            }
            
        }
        
        public static int ConvertiStringaInIntero(string stringaDaConvertire)
        {
            int numeroConvertito;
            if (int.TryParse(stringaDaConvertire, out int result))
            {
                numeroConvertito = result;
                return numeroConvertito;
            }
            else
            {
                throw new ArgumentException("La stringa deve contenere solo numeri interi");
            }
        }

       
    }
}
