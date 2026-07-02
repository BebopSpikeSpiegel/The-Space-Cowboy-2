using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class Bang : SpaceCowboyCard
{
    public Bang() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        WithCalculatedDamage(12, 4, (card, _) => Flow.AmountOn(card.Owner.Creature));
        WithVar("PerFlow", 4);
        WithVar("Weight", 8, -8);
        WithKeywords(CardKeyword.Exhaust);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        await Flow.Spend(choiceContext, Owner.Creature, Flow.AmountOn(Owner.Creature));
        int weight = DynamicVars["Weight"].IntValue;
        if (weight > 0)
        {
            await CommonActions.ApplySelf<TheWeight>(this, weight);
        }
    }
}
