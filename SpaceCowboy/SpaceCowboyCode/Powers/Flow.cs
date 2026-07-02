using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Powers;

/// <summary>
/// Flow: Spike's combat momentum. Builders add it, spenders consume it, payoffs check
/// "In the Flow" (3+ Flow). Pure counter — all behavior lives on the cards that read it.
/// </summary>
public class Flow : SpaceCowboyPower
{
    /// <summary>You are "In the Flow" while you have at least this much Flow.</summary>
    public const int InTheFlowThreshold = 3;

    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public static int AmountOn(Creature creature)
    {
        var power = creature.GetPower<Flow>();
        return power?.Amount ?? 0;
    }

    public static bool IsInTheFlow(Creature creature) => AmountOn(creature) >= InTheFlowThreshold;
}
