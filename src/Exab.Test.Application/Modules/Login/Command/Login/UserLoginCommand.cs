using Exab.Test.Application.Modules.Login.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Modules.Login.Command.Login;
public  class UserLoginCommand :IRequest<UserLoginDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
