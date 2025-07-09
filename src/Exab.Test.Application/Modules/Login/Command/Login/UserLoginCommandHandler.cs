using Exab.Test.Application.Common.Services.SecurityService;
using Exab.Test.Application.Modules.Login.DTOs;
using Exab.Test.Domain.Entities;

namespace Exab.Test.Application.Modules.Login.Command.Login;
public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserLoginDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher ;
    private readonly IJwtProvider _jwtProvider ;
   

    public UserLoginCommandHandler(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public  async Task<UserLoginDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        #region  Used For Make New User 
        //string hashedPassword = _passwordHasher.HashPassword(request.Password);
        //User newUser= new User{ Username=request.Username ,
        //                        Email="Keroloshenry182@gmail.com",
        //                        EmailConfirmed=false,
        //                        phoneConfirmed=false,
        //                        PhoneNumber="01277346235",
        //                        PasswordHash=hashedPassword,
        //                      };
        //await _unitOfWork.User.Insert(newUser, cancellationToken);
        //await _unitOfWork.CommitAsync(cancellationToken);
        //var userLoginDto = new UserLoginDto { 
        //UserId= newUser.Id
        //};
        //return userLoginDto; 
        #endregion

        var user = await  _unitOfWork.User.Where(c=>c.Username==request.Username).FirstOrDefaultAsync(cancellationToken);

        ArgumentNullException.ThrowIfNull(user, "UserName Or Password InValid");

        var isValid = _passwordHasher.VerifyPassword(request.Password, user.PasswordHash!);
        if (!isValid)
            throw new UnauthorizedAccessException("Username or password is invalid");

        var tokenAndExpirein = _jwtProvider.GenerateTokens(user);
        UserLoginDto userLoginDto = new UserLoginDto
        {
            UserId = user.Id,
            token = tokenAndExpirein.token,
            Success = true,
            ExpireIn=tokenAndExpirein.expeireIn,
        };
        return  userLoginDto;
    }
}
