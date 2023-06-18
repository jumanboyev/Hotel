
using System.ComponentModel.DataAnnotations;

namespace Hotel.Entities.Positions;

public class Position
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Describtion { get; set; } = string.Empty;

}
