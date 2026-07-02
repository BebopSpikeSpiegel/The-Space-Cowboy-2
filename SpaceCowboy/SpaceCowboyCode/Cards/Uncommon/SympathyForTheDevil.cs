using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class SympathyForTheDevil : SpaceCowboyCard
{
    public SympathyForTheDevil() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        WithDamage(7, 2);
        WithVar("Heal", 2);
        WithVar("FlowHeal", 5);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        int heal = Flow.IsInTheFlow(Owner.Creature)
            ? DynamicVars["FlowHeal"].IntValue
            : DynamicVars["Heal"].IntValue;
        await CreatureCmd.Heal(Owner.Creature, heal);
    }
}
