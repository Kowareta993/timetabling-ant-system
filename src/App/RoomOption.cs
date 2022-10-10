using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public abstract class RoomOption
{
    [Key] public int Id { get; set; }
    public abstract bool HasRequirement(RoomOption o);
    public abstract double OptionCost(RoomOption o);
}