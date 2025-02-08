using SQLite;

namespace People.Models;

[Table("Persona")]
public class Person
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string nombre { get; set; }
}
