using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("parent")]
public class Parent : BaseEntity
{
    public string email { get; set; }
    public string password { get; set; }
    public string fname { get; set; }
    public string iname { get; set; }
    public DateTime dob { get; set; }
    public DateTime last_login_date { get; set; }
    public string? last_login_ip { get; set; }
    public string phone { get; set; }
    public string mobile { get; set; }
    public bool status { get; set; }
}