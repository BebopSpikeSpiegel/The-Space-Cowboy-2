using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class GreenBird : SpaceCowboyCard
{
    public GreenBird() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        WithBlock(5, 2);
        WithPower<DexterityPower>("Dexterity", 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
        await CommonActions.ApplySelf<DexterityPower>(this, DynamicVars["Dexterity"].IntValue);
    }
}
