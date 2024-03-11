using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("course")]
public class Course : BaseEntity
{
    public string name { get; set; }
    public string description { get; set; }
    public int grade_id { get; set; }
}