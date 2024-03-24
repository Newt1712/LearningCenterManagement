using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("users")]
public class Users : BaseEntity
{
    public int user_id { get; set; }
    public string user_name { get; set; }
    public string salt { get; set; }
    public string password { get; set; }
    public string Salt { get; set; }
    public int type { get; set; }
    public bool is_active { get; set; }
}