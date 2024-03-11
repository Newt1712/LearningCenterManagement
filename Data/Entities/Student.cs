using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("student")]
public class Student : BaseEntity
{
    public string email { get; set; }
    public string password { get; set; }
    public string fname { get; set; }
    public string iname { get; set; }
    public DateTime dob { get; set; }
    public DateTime last_login_date { get; set; }
    public DateTime date_of_join { get; set; }
    public string? last_login_ip { get; set; }
    public string phone { get; set; }
    public string mobile { get; set; }
    public bool status { get; set; }
    public int parent_id { get; set; }
}