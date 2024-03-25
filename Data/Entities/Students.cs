using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("students")]
public class Students : BaseEntity
{
    public string fullname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public DateTime dob { get; set; }
    public int parent_id { get; set; }
    public bool isDeleted { get; set; }
}