using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Basic;

public class Dodge : SpaceCowboyCard
{
    public Dodge() : base(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
    {
        WithBlock(5, 3);
        WithTags(CardTag.Defend);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
    }
}
