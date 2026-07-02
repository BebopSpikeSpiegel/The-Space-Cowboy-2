using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class Blue : SpaceCowboyCard
{
    public Blue() : base(3, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        WithPower<BluePower>("Flow", 1);
        WithCostUpgradeBy(-1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<BluePower>(this, DynamicVars["Flow"].IntValue);
    }
}
