using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SpaceCowboy.SpaceCowboyCode.Powers;

/// <summary>Blue: whenever you play a card, gain Amount Flow.</summary>
public class BluePower : SpaceCowboyPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner.Creature != Owner)
        {
            return;
        }
        await CommonActions.Apply<Flow>(Owner, null, Amount);
    }
}
