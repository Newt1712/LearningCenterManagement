using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("grade")]
public class Grade : BaseEntity
{
    public string name { get; set; }
    public string desc { get; set; }
}