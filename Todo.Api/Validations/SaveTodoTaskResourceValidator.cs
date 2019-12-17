using FluentValidation;
using Todo.Api.Resources;

namespace Todo.Api.Validations
{
    public class SaveTodoTaskResourceValidator : AbstractValidator<TodoTaskResource>
    {
        public SaveTodoTaskResourceValidator()
        {
            RuleFor(m => m.Description)
                .NotEmpty()
                .MaximumLength(250);

        }
    }
}
