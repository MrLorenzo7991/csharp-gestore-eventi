using GestoreEventi;
using GestoreEventi.Eccezioni;
using GestoreEventi.MetodiStatici;

Console.WriteLine("Benvenuto nel gestore di eventi!");
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
    }catch(InvalidDataException e)
    {
        Console.WriteLine("La data dell'evento non puù essere nel passato");
    }
}

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