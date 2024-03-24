using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("students_subject")]
public class Students_Subject
{
    public int student_id { get; set; }
    public int subject_id { get; set; }
    public decimal buyingPrice { get; set; }
    public DateTime buyingDate { get; set; }
}