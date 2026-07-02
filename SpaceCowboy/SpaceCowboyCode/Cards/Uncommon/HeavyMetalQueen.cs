using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class HeavyMetalQueen : SpaceCowboyCard
{
    public HeavyMetalQueen() : base(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        WithCalculatedDamage(10, 3, (card, _) => Flow.AmountOn(card.Owner.Creature), upgrade: 2);
        WithVar("PerFlow", 3);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        await Flow.Spend(choiceContext, Owner.Creature, Flow.AmountOn(Owner.Creature));
    }
}
