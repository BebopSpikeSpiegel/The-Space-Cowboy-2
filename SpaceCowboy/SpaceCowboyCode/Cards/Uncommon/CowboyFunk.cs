using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class CowboyFunk : SpaceCowboyCard
{
    public CowboyFunk() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        WithDamage(5, 1);
        WithVar("Hits", 2);
        WithVar("FlowSpend", 3);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        int hits = DynamicVars["Hits"].IntValue;
        if (Flow.IsInTheFlow(Owner.Creature))
        {
            await Flow.Spend(choiceContext, Owner.Creature, DynamicVars["FlowSpend"].IntValue);
            hits += 1;
        }
        await CommonActions.CardAttack(this, play.Target, hits).Execute(choiceContext);
    }
}
