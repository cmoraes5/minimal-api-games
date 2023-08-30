using FluentValidation;

namespace MinimalGameApi.Vlidators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            // Caso um campo seja enviado vazio
            RuleFor(game => game.Titulo).NotEmpty().WithMessage("O titulo do jogo e obrigatorio.");
            RuleFor(game => game.Descricao).NotEmpty().WithMessage("A descrição do jogo e obrigatória.");
            RuleFor(game => game.Desenvolvedores).NotEmpty().WithMessage("O desenvolvedor do jogo e obrigatória.");

            // Caso um campo exceda o número máximo de caracteres estipulado
            RuleFor(game => game.Titulo).MaximumLength(100).WithMessage("O nome do jogo nao pode exceder 100 caracteres.");
            RuleFor(game => game.Modo).MaximumLength(74).WithMessage("Os modo de jogo nao podem exceder 74 caracteres.");
            RuleFor(game => game.Descricao).MaximumLength(380).WithMessage("A descricao do jogo nao pode exceder 380 caracteres.");
            RuleFor(game => game.Desenvolvedores).MaximumLength(120).WithMessage("Os desenvolvedores do jogo nao pode exceder 120 caracteres.");
        }
    }
}
