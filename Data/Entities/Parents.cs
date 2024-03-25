using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("parents")]
public class Parents : BaseEntity
{
    public string fullname { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime dob { get; set; }
}