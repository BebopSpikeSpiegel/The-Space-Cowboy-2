using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class BalladOfFallenAngels : SpaceCowboyCard
{
    public BalladOfFallenAngels() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
    {
        WithDamage(8, 3);
        WithPower<Flow>("Flow", 2);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        foreach (var enemy in CombatState!.HittableEnemies)
        {
            await CommonActions.CardAttack(this, enemy).Execute(choiceContext);
        }
        await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
    }
}
