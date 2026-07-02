using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Basic;

public class Shoot : SpaceCowboyCard
{
    public Shoot() : base(1, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
    {
        WithDamage(5, 3);
        WithPower<VulnerablePower>("Vulnerable", 1, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        if (play.Target != null)
        {
            await CommonActions.Apply<VulnerablePower>(play.Target, this, DynamicVars["Vulnerable"].IntValue);
        }
    }
}
