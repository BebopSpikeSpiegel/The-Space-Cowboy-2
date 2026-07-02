using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Powers;

/// <summary>Jupiter Jazz: at end of turn, if In the Flow (3+ Flow), gain Amount Strength.</summary>
public class JupiterJazzPower : SpaceCowboyPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task BeforeSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side,
        IEnumerable<Creature> creatures)
    {
        if (side != CombatSide.Player || !creatures.Contains(Owner) || !Flow.IsInTheFlow(Owner))
        {
            return;
        }
        await CommonActions.Apply<StrengthPower>(Owner, null, Amount);
    }
}
