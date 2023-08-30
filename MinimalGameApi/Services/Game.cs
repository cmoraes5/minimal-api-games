﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Game
{
    //[JsonIgnore]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Titulo { get; set; }

    [MaxLength(74)]
    public string? Modo { get; set; }

    [MaxLength(380)]
    public string Descricao { get; set; }

    [MaxLength(120)]
    public string Desenvolvedores { get; set; }

}
