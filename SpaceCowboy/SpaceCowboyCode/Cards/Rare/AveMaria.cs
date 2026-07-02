using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class AveMaria : SpaceCowboyCard
{
    public AveMaria() : base(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        WithDamage(8, 2);
        WithVar("FlowDamage", 20, 4);
        WithKeywords(CardKeyword.Exhaust);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        if (Flow.IsInTheFlow(Owner.Creature))
        {
            await CommonActions.CardAttack(this, play.Target, DynamicVars["FlowDamage"].IntValue).Execute(choiceContext);
        }
        else
        {
            await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        }
    }
}
