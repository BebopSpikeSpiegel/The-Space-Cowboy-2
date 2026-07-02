using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Basic;

public class JeetKuneDo : SpaceCowboyCard
{
    public JeetKuneDo() : base(1, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
    {
        WithDamage(6, 2);
        WithPower<Flow>("Flow", 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
    }
}
