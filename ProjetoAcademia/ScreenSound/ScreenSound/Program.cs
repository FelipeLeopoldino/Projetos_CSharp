//Banda queen = new Banda("Queen");

//Album albumDoQueen = new Album("A night at the opera");

//Musica musica1 = new Musica(queen, "Love of my life")
//{
//Duracao = 123,
//  Disponivel = true
//};
Episodio ep1 = new(1, "Técnicas de facilitação", 45);
ep1.AdicionarConvidados("Felipe");
ep1.AdicionarConvidados("Aline");
ep1.AdicionarConvidados("Maria");

Episodio ep2 = new(2, "Técnicas de aprendizado", 65);
ep2.AdicionarConvidados("Maria Luiza");
ep2.AdicionarConvidados("Felipe Leopoldino");
ep2.AdicionarConvidados("Aline Leopoldino");

Episodio ep3 = new(3, "Técnicas de comunicação", 55);
ep3.AdicionarConvidados("Larissa");
ep3.AdicionarConvidados("Geovane");
ep3.AdicionarConvidados("Olivia");

Podcast podcast = new("Podcast Da Familia", "Carlos Felipe");
podcast.AdicionarEpisodio(ep1);
podcast.AdicionarEpisodio(ep2);
podcast.AdicionarEpisodio(ep3);

podcast.ExibirDetalhes();
