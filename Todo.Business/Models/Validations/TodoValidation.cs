using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Business.Models.Validations
{
    public class TodoValidation : AbstractValidator<TodoModel>
    {
        public TodoValidation()
        {
            RuleFor(t => t.Name)
               .NotEmpty().WithMessage("{PropertyName} field needs to be provided")
               .Length(2, 20).WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength} caracters");

            RuleFor(t => t.UserId)
              .NotEmpty().WithMessage("{PropertyName} field needs to be provided");

            RuleFor(t => t.Id).NotEmpty().WithMessage("{PropertyName} field needs to be provided");
        }

    }
}