using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace SpaceCowboy.SpaceCowboyCode.Powers;

/// <summary>
/// Ask DNA: the next Attack you play this turn is played Amount extra times.
/// Consumed when that Attack resolves; expires at end of turn.
/// </summary>
public class AskDnaPower : SpaceCowboyPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override int ModifyCardPlayCount(CardModel card, Creature owner, int playCount)
    {
        if (owner != Owner || card.Type != CardType.Attack)
        {
            return playCount;
        }
        return playCount + Amount;
    }

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner.Creature != Owner || cardPlay.Card.Type != CardType.Attack
            || !cardPlay.IsLastInSeries)
        {
            return;
        }
        await PowerCmd.Remove(this);
    }

    public override async Task BeforeSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side,
        IEnumerable<Creature> creatures)
    {
        if (side == CombatSide.Player && creatures.Contains(Owner))
        {
            await PowerCmd.Remove(this);
        }
    }
}
