using GestoreEventi;
using GestoreEventi.Eccezioni;
using GestoreEventi.MetodiStatici;

Console.WriteLine("Benvenuto nel gestore di eventi!");

Evento ChiediEvento() 
{
    Evento evento = null;
    bool inserimentoEventoCorretto = false;
    while (!inserimentoEventoCorretto)
    {
        Console.Write("Inserici il nome dell'evento che vuoi aggiungere: ");
        string nomeEvento = Console.ReadLine();

        Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
        DateTime dataEvento = DateTime.Now;
        bool formatoDataCorretto = false;
        while (!formatoDataCorretto)
        {
            string dataEventoInStringa = Console.ReadLine();
            try
            {
                dataEvento = ControlloInput.ControllaFormatoData(dataEventoInStringa);
                formatoDataCorretto=true;
            }catch(Exception e)
            {
                Console.Write("La data non è in un formato corretto, riprova: ");
            }
        }

        Console.Write("Inserisci la capienza massima dell'evento: ");
        int capienzaMassima = 0;
        bool formatoCapienzaMassimaCorretto = false;
        while (!formatoCapienzaMassimaCorretto)
        {
        string capienzaMassimaInStringa = Console.ReadLine();
            try
            {
                capienzaMassima = ControlloInput.ConvertiStringaInIntero(capienzaMassimaInStringa); 
                if (capienzaMassima < 0)
                {
                    Console.WriteLine("Il numero di posti deve essere maggiore di 0, riprova");
                }
                else
                {
                    formatoCapienzaMassimaCorretto = true;
                }
            }catch(ArgumentException e)
            {
                Console.Write("Inserisci solo numeri interi: ");
            }
        }

        try
        {
            evento = new Evento(nomeEvento, dataEvento, capienzaMassima);      
            inserimentoEventoCorretto = true;            
        }
        catch(InvalidDataException e)
        {
            Console.WriteLine("La data dell'evento non puù essere nel passato");
        }
    }

    return evento;
}

Evento evento = ChiediEvento();
bool postiPreontatiOk = false;
while(!postiPreontatiOk){ 
    Console.Write("Quanti posti desideri prenotare?");
    try
    {
        evento.Prenota(ControlloInput.ConvertiStringaInIntero(Console.ReadLine()));
        postiPreontatiOk = true;
    }catch(NumeroUgualeOInferioreAZero e)
    {
        Console.WriteLine("Non puoi inserire un valore inferirore o uguale a 0");
    }catch(ArgumentOutOfRangeException e)
    {
        Console.WriteLine("Non è disponibile questo numero di posti");
    }
}

Console.WriteLine("Numero posti prenotati: " + evento.GetNumeroPostiPrenotati());
Console.WriteLine("Numero posti disponibili: " + evento.GetNumeroPostiDisponibili());
bool vuoiDisdirePosti = true;
while (vuoiDisdirePosti)
{
    Console.Write("Vuoi disdire dei posti [si/no]? ");
    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "si":
            Console.Write("Quanti posti vuoi disdire?");
            try
            {
                evento.Disdici(ControlloInput.ConvertiStringaInIntero(Console.ReadLine())); 
            }catch(NumeroUgualeOInferioreAZero e)
            {
                Console.WriteLine("Non puoi inserire un valore inferirore o uguale a 0");
            }catch(DataEventoPassata e)
            {
                Console.WriteLine(e.Message);
            }catch(NessunPostoPrenotato e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Numero posti prenotati: " + evento.GetNumeroPostiPrenotati());
            Console.WriteLine("Numero posti disponibili: " + evento.GetNumeroPostiDisponibili());
            break;
        case "no":
            Console.WriteLine("Ok, va bene!");
            Console.WriteLine("Numero posti prenotati: " + evento.GetNumeroPostiPrenotati());
            Console.WriteLine("Numero posti disponibili: " + evento.GetNumeroPostiDisponibili());
            vuoiDisdirePosti =false;
            break;
        default:
            Console.WriteLine("Non hai selezionato un opzione valida, riprova");
            break;
    }
}
Console.WriteLine(evento.ToString());

//Programma di eventi

Console.WriteLine("Ora creiamo un programma di eventi");
Console.Write("Come vuoi chiamare il tuo programma di eventi? ");
ProgrammaEventi programma = new ProgrammaEventi(Console.ReadLine());
Console.WriteLine("Quanti eventi vuoi aggiungere nel tuo programma? ");
int numeroDiEventi = 0;
bool numeroDiEventiOk = false;
while(!numeroDiEventiOk)
{
    try
    {
        numeroDiEventi = ControlloInput.ConvertiStringaInIntero(Console.ReadLine()); 
        if (numeroDiEventi < 0)
        {
            Console.WriteLine("Seleziona un numero positivo");
        }
        else
        {
            numeroDiEventiOk = true;
        }

    }catch(Exception e)
    {
        Console.WriteLine("Formato numero non valido, riprova");
    }
}

for(int i = 0; i < numeroDiEventi; i++)
{
    Console.WriteLine("Evento numero " + (i+1));
    Evento eventoProgramma = ChiediEvento();
    programma.AggiungiEvento(eventoProgramma);
}

Console.WriteLine("Il numero di eventi presente nella lista è di: " + programma.NumeroEventiLista());
Console.WriteLine("Ecco il tuo Programma di eventi: ");
Console.WriteLine(programma.StampaTuttoIlProgramma());

Console.Write("Inserisci una data per conoscere tutti gli eventi in quella data: ");
DateTime dataDaControllare = DateTime.Now;
bool formatoDataCorretto = false;
while (!formatoDataCorretto)
{
    string dataEventoInStringa = Console.ReadLine();
    try
    {
        dataDaControllare = ControlloInput.ControllaFormatoData(dataEventoInStringa);
        formatoDataCorretto = true;
    }
    catch (Exception e)
    {
        Console.Write("La data non è in un formato corretto, riprova: ");
    }
}
List<Evento> eventiNellaDatataSpecifica = programma.EventiNellaData(dataDaControllare);
if (eventiNellaDatataSpecifica.Count > 0)
{
    Console.WriteLine("La lista di eventi in data " + dataDaControllare.ToString("dd/MM/yyyy") + " è");
    ProgrammaEventi.StampaLista(eventiNellaDatataSpecifica);
}
else
{
    Console.WriteLine("Nessun evento per quella data.");
}
//programma.SvuotaListaEventi();

Console.WriteLine("---------BONUS---------\n\n");
Console.WriteLine("Aggiungiamo un conferenza!");

Console.Write("Inserisci il nome della conferenza: ");
string nomeCoferenza = Console.ReadLine();

Console.Write("Inserisci data della conferenza: ");
DateTime dataConferenza = DateTime.Now;
bool formatoDataConferenzaCorretto = false;
while (!formatoDataConferenzaCorretto)
{
    string dataConferenzaInStringa = Console.ReadLine();
    try
    {
        dataConferenza = ControlloInput.ControllaFormatoData(dataConferenzaInStringa);
        formatoDataConferenzaCorretto = true;
    }
    catch (Exception e)
    {
        Console.Write("La data non è in un formato corretto, riprova: ");
    }
}

Console.Write("Inserisci il relatore della conferenza: ");
string relatoreConferenza = Console.ReadLine();

Console.Write("Inserisci numero posti della conferenza: ");
int capienzaMassimaConferenza = 0;
bool formatoCapienzaMassimaCorretto = false;
while (!formatoCapienzaMassimaCorretto)
{
    string capienzaMassimaInStringa = Console.ReadLine();
    try
    {
        capienzaMassimaConferenza = ControlloInput.ConvertiStringaInIntero(capienzaMassimaInStringa);
        if (capienzaMassimaConferenza < 0)
        {
            Console.WriteLine("Il numero di posti deve essere maggiore di 0");
        }
        else
        {
            formatoCapienzaMassimaCorretto = true;
        }
    }
    catch (ArgumentException e)
    {
        Console.Write("Inserisci solo numeri interi: ");
    }
}

Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
bool prezzoBigliettoOk = false;
double prezzoBiglietto = 0;
while (!prezzoBigliettoOk)
{
    try
    {
        prezzoBiglietto = double.Parse(Console.ReadLine());
        prezzoBigliettoOk = true;
    }
    catch(Exception e)
    {
        Console.WriteLine("inserisci il prezzo nel formato corretto");
    }
}

Conferenza confereza = new Conferenza(nomeCoferenza, dataConferenza, capienzaMassimaConferenza, relatoreConferenza, prezzoBiglietto);
programma.AggiungiEvento(confereza);
Console.WriteLine(programma.StampaTuttoIlProgramma());
