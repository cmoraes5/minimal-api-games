var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var games = new List<Game>()
{
    new Game { Id = 1, Titulo = "Homem Aranha", Descricao = "Neste game, Peter Parker experiente e mais preparado para enfrentar a onda de crimes de Nova York. Em contrapartida, ele luta para conciliar sua vida pessoal e carreira caóticas enquanto o destino de milhões de nova-iorquinos pesa sobre seus ombros", Modo = "1 Jogador", Desenvolvedores = "Insomniac Games" },

    new Game { Id = 2, Titulo = "Grand Theft Auto V", Descricao = "O game se passa no estado ficcional de San Andreas, baseado na Califórnia do Sul, nos EUA. Traz a história de campanha simultânea de três criminosos: o ladrão de bancos aposentado Michael 'Mike' De Santa, o gângster de rua Franklin Clinton e o traficante de armas psicopata Trevor Philips.", Modo = "1 Jogador, Multijogador online", Desenvolvedores = "Rockstar Games, Rockstar North" },

    new Game { Id = 3, Titulo = "Cuphead", Descricao = "Cuphead é um jogo eletrônico de run and gun e plataforma criado pelos irmãos canadenses Chad e Jared Moldenhauer através da Studio MDHR. O jogo foi inspirado no estilo de animação Rubber hose usado em desenhos animados da Era de Ouro da animação americana, como o trabalho dos estúdios Fleischer Studios, Warner Bros.", Modo = "1 Jogador, Multijogador local, Multijogador online", Desenvolvedores = "Studio MDHR" },

    new Game { Id = 4, Titulo = "Overwatch", Descricao = "Como um bom game do genero hero shooter, Overwatch designa jogadores em dois times de seis, com cada jogador tendo liberdade em escolher mais de 30 personagens, conhecidos como 'heróis', cada um com um estilo de jogo único, dividido em três papéis gerais adequados ao seu objetivo.", Modo = "Multijogador online", Desenvolvedores = "Blizzard Entertainment, Iron Galaxy Studios" },

    new Game { Id = 5, Titulo = "Assassin's Creed Valhalla", Descricao = "No ano de 855 DC, uma jovem Eivor (o jogador tem a opção de escolher se Eivor é homem ou mulher, porém, canonicamente Eivor é mulher) testemunha seu clã ser massacrado e seus pais serem mortos por Kjotve, o Cruel durante uma festa para celebrar a aliança entre o clã de Varin e o clã do Corvo.", Modo = "1 Jogador", Desenvolvedores = "Ubisoft Montreal" },
};

app.Run();

class Game
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public string Modo { get; set; }

    public string Desenvolvedores { get; set; }

}
