using FluentValidation;

namespace MinimalGameApi.Validators
{
    public class GameDTOValidator : AbstractValidator<GameDTO>
    {
        public GameDTOValidator()
        {
            RuleFor(gameDTO => gameDTO.Titulo).NotEmpty().WithMessage("O título do jogo é obrigatório.");
            RuleFor(gameDTO => gameDTO.Descricao).NotEmpty().WithMessage("A descrição do jogo é obrigatória.");
            RuleFor(gameDTO => gameDTO.Desenvolvedores).NotEmpty().WithMessage("O desenvolvedor do jogo é obrigatório.");

            RuleFor(gameDTO => gameDTO.Titulo).MaximumLength(100).WithMessage("O nome do jogo não pode exceder 100 caracteres.");
            RuleFor(gameDTO => gameDTO.Modo).MaximumLength(74).WithMessage("Os modos de jogo não podem exceder 74 caracteres.");
            RuleFor(gameDTO => gameDTO.Descricao).MaximumLength(380).WithMessage("A descrição do jogo não pode exceder 380 caracteres.");
            RuleFor(gameDTO => gameDTO.Desenvolvedores).MaximumLength(120).WithMessage("Os desenvolvedores do jogo não podem exceder 120 caracteres.");
        }
    }
}
