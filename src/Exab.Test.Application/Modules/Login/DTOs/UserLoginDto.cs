using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exab.Test.Application.Modules.Login.DTOs;
public  class UserLoginDto
{
    public string  token { get; set; }
    public bool Success { get; set; }
    public int? UserId { get; set; }
    public int ExpireIn { get; set; }
}
