using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class MushroomHunting : SpaceCowboyCard
{
    public MushroomHunting() : base(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        WithPower<Flow>("Flow", 2, 1);
        WithCards(1);
        WithKeywords(CardKeyword.Exhaust);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
        await CommonActions.Draw(this, choiceContext);
    }
}
