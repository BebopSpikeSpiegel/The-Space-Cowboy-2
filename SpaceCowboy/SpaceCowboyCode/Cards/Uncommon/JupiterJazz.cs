using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class JupiterJazz : SpaceCowboyCard
{
    public JupiterJazz() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    {
        WithPower<JupiterJazzPower>("Strength", 1, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<JupiterJazzPower>(this, DynamicVars["Strength"].IntValue);
    }
}
