using Data.Models.Common;

namespace Data.Models.RequestModel;

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
}