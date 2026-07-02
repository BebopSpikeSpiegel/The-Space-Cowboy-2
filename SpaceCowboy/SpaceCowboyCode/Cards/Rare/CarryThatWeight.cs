using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class CarryThatWeight : SpaceCowboyCard
{
    public CarryThatWeight() : base(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        WithCalculatedDamage(3, 3,
            (card, _) => card.Owner.PlayerCombatState.ExhaustPile.Cards.Count,
            bonusUpgrade: 1);
        WithVar("PerCard", 3, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
    }
}
