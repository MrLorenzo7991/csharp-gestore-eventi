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
                capienzaMassima = ControlloInput.ConvertiStringaInIntero(capienzaMassimaInStringa);     //aggiungere controllo su numeri negativi
                formatoCapienzaMassimaCorretto=true;
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

Console.Write("Quanti posti desideri prenotare?");
evento.Prenota(ControlloInput.ConvertiStringaInIntero(Console.ReadLine()));     //da gestire eccezzione
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
            evento.Disdici(ControlloInput.ConvertiStringaInIntero(Console.ReadLine())); //da gestire ecczione
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
int numeroDiEventi = ControlloInput.ConvertiStringaInIntero(Console.ReadLine());        //da gestire eccezione numero intero

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
if (eventiNellaDatataSpecifica.Count < 0)
{
    Console.WriteLine("La lista di eventi in data " + dataDaControllare.ToString("dd/MM/yyyy") + " è");
    ProgrammaEventi.StampaLista(eventiNellaDatataSpecifica);
}
else
{
    Console.WriteLine("Nessun evento per quella data.");
}
//programma.SvuotaListaEventi();

DateTime dataConferenza = new DateTime(2999, 12, 1);
Conferenza conferezaAppezzottata = new Conferenza("Come non sclerare programmando", dataConferenza, 300, "Dott. Zen", 2.41);
programma.AggiungiEvento(conferezaAppezzottata);
Console.WriteLine(programma.StampaTuttoIlProgramma());
