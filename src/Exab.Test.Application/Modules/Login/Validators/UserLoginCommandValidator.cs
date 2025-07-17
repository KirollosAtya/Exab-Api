using Exab.Test.Application.Modules.Login.Command.Login;

namespace Exab.Test.Application.Modules.Login.Validators;
public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(c => c.Username).NotNull().NotEmpty().WithMessage("Name is required"); // (Kirollos Note ) =>    not best Pracitice to Use Message  String Must Used SharedResoures  

        RuleFor(c => c.Password)
                  .NotEmpty().WithMessage("Password is required.");
                  
    }
}
