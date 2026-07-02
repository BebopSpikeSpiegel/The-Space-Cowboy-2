using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class JammingWithEdward : SpaceCowboyCard
{
    public JammingWithEdward() : base(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        WithCards(2, 1);
        WithKeywords(CardKeyword.Exhaust);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        int handCount = Owner.PlayerCombatState.Hand.Cards.Count;
        if (handCount > 0)
        {
            await CommonActions.Apply<Flow>(Owner.Creature, this, handCount);
        }
        await CommonActions.Draw(this, choiceContext);
    }
}
