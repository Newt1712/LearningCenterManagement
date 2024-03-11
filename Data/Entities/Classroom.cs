using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("classroom")]
public class Classroom : BaseEntity
{
    public DateTime year { get; set; }
    public int grade_id { get; set; }
    public string section { get; set; }
    public double status { get; set; }
    public int teacher_id { get; set; }
}