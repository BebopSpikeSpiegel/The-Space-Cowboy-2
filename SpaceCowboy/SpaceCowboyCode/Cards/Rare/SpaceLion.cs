using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class SpaceLion : SpaceCowboyCard
{
    public SpaceLion() : base(2, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        WithPower<SpaceLionPower>("Strength", 1, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<SpaceLionPower>(this, DynamicVars["Strength"].IntValue);
    }
}
