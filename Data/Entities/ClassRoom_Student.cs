using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("classRoom_student")]
public class ClassRoom_Student
{
    public int student_id { get; set; }
    public int classroom_id { get; set; }
}