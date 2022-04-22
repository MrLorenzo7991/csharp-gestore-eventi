using GestoreEventi;
using GestoreEventi.Eccezioni;

DateTime dataEvento = new DateTime(2022,12,01);

Evento eventoProva = new Evento("Evento di prova bello", dataEvento, 120);

eventoProva.Prenota();
eventoProva.Prenota();

Console.WriteLine(eventoProva.GetnumeroPostiPrenotati());

eventoProva.Disdici();

Console.WriteLine(eventoProva.GetnumeroPostiPrenotati());

Console.WriteLine(eventoProva.ToString());