using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class Room
{
    [Key] public int RoomId { get; set; }
    public string Name { get; set; }
    public virtual List<RoomOption> Options { get; set; }

    public virtual List<ProposedRoom> ProposedRooms { get; set; }
    public List<ConfirmedRoom> ConfirmedRooms { get; set; }

    [NotMapped] public int capacity;
    [NotMapped] public bool has_projector;

    public override string ToString()
    {
        return $"{this.Name}";
    }

    public bool HasOption(RoomOption option)
    {
        return Options.Any(roomOption => roomOption.HasRequirement(option));
    }

    public int HasOptions(RoomOption[] options)
    {
        return options.Count(roomOption => !HasOption(roomOption));
    }

    public double ExtraOption(RoomOption option)
    {
        return Options.Sum(roomOption => roomOption.OptionCost(option));
    }

    public double ExtraOptions(RoomOption[] options)
    {
        return options.Sum(roomOption => ExtraOption(roomOption));
    }
}