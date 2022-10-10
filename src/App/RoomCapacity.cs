using System.ComponentModel.DataAnnotations.Schema;

namespace App;

public class RoomCapacity : RoomOption
{
    public int Capacity { get; set; }
    

    public override bool HasRequirement(RoomOption o)
    {
        if (o is not RoomCapacity option)
            return false;
        return this.Capacity >= option.Capacity;
    }

    public override double OptionCost(RoomOption o)
    {
        if (HasRequirement(o))
        {
            return this.Capacity - ((RoomCapacity)o).Capacity;
        }

        return 0;
    }
}