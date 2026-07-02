using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class MyFunnyValentine : SpaceCowboyCard
{
    public MyFunnyValentine() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        WithCalculatedBlock(0, 1, (card, _) => Flow.AmountOn(card.Owner.Creature), bonusUpgrade: 1);
        WithVar("PerFlow", 1, 1);
        WithKeywords(CardKeyword.Retain);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
    }
}
