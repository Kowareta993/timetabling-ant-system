namespace App;

public class RoomHasProjector : RoomOption
{
    public bool Projector { get; set; }
    public override bool HasRequirement(RoomOption o)
    {
        return o is RoomHasProjector option && this.Projector;
    }

    public override double OptionCost(RoomOption o)
    {
        return 0;
    }
}