using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class Tank : SpaceCowboyCard
{
    public Tank() : base(1, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        WithPower<TankPower>("Flow", 2, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<TankPower>(this, DynamicVars["Flow"].IntValue);
    }
}
