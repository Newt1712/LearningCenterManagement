using Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("teacher")]
public class Teachers : BaseEntity
{
    public string email { get; set; }
    public string password { get; set; }
    public string fullname { get; set; }
    public string username { get; set; }
    public string phone { get; set; }
    public SubjectType subjectType { get; set; }
    public bool status { get; set; }
    public bool is_admin { get; set; }
}