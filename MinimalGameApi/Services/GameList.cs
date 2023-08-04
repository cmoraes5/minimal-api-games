namespace MinimalGameApi.Services
{
    public class GameList
    {
        public List<Game> Games { get; set; }

        public GameList()
        {
            Games = new List<Game>();
            Games.AddRange(new List<Game>
            {
                new Game { Id = 1, Titulo = "Homem Aranha", Descricao = "Neste game, Peter Parker experiente e mais preparado para enfrentar a onda de crimes de Nova York. Em contrapartida, ele luta para conciliar sua vida pessoal e carreira ca�ticas enquanto o destino de milh�es de nova-iorquinos pesa sobre seus ombros", Modo = "1 Jogador", Desenvolvedores = "Insomniac Games" },

                new Game { Id = 2, Titulo = "Grand Theft Auto V", Descricao = "O game se passa no estado ficcional de San Andreas, baseado na Calif�rnia do Sul, nos EUA. Traz a hist�ria de campanha simult�nea de tr�s criminosos: o ladr�o de bancos aposentado Michael 'Mike' De Santa, o g�ngster de rua Franklin Clinton e o traficante de armas psicopata Trevor Philips.", Modo = "1 Jogador, Multijogador online", Desenvolvedores = "Rockstar Games, Rockstar North" },

                new Game { Id = 3, Titulo = "Cuphead", Descricao = "Cuphead � um jogo eletr�nico de run and gun e plataforma criado pelos irm�os canadenses Chad e Jared Moldenhauer atrav�s da Studio MDHR. O jogo foi inspirado no estilo de anima��o Rubber hose usado em desenhos animados da Era de Ouro da anima��o americana, como o trabalho dos est�dios Fleischer Studios, Warner Bros.", Modo = "1 Jogador, Multijogador local, Multijogador online", Desenvolvedores = "Studio MDHR" },

                new Game { Id = 4, Titulo = "Overwatch", Descricao = "Como um bom game do genero hero shooter, Overwatch designa jogadores em dois times de seis, com cada jogador tendo liberdade em escolher mais de 30 personagens, conhecidos como 'her�is', cada um com um estilo de jogo �nico, dividido em tr�s pap�is gerais adequados ao seu objetivo.", Modo = "Multijogador online", Desenvolvedores = "Blizzard Entertainment, Iron Galaxy Studios" },

                new Game { Id = 5, Titulo = "Assassin's Creed Valhalla", Descricao = "No ano de 855 DC, uma jovem Eivor (o jogador tem a op��o de escolher se Eivor � homem ou mulher, por�m, canonicamente Eivor � mulher) testemunha seu cl� ser massacrado e seus pais serem mortos por Kjotve, o Cruel durante uma festa para celebrar a alian�a entre o cl� de Varin e o cl� do Corvo.", Modo = "1 Jogador", Desenvolvedores = "Ubisoft Montreal" },
            });
        }
    }
}
