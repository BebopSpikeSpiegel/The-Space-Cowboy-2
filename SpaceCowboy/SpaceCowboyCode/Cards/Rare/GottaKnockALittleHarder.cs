using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Rare;

public class GottaKnockALittleHarder : SpaceCowboyCard
{
    public GottaKnockALittleHarder() : base(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        WithDamage(9, 3);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        var creature = Owner.Creature;
        bool desperate = creature.CurrentHp * 2 <= creature.MaxHp;
        if (desperate)
        {
            await CommonActions.CardAttack(this, play.Target, DynamicVars.Damage.BaseValue * 2).Execute(choiceContext);
        }
        else
        {
            await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        }
    }
}
