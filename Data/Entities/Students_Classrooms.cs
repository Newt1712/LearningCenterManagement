using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("students_classrooms")]
public class Students_Classrooms
{
    public int student_id { get; set; }
    public int classroom_id { get; set; }
    public DateTime joined_at { get; set; }
}