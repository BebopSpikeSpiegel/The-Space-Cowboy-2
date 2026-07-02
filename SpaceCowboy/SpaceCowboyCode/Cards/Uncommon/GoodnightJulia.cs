using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class GoodnightJulia : SpaceCowboyCard
{
    public GoodnightJulia() : base(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        WithVar("HpLoss", 3);
        WithPower<Flow>("Flow", 2, 1);
        WithCards(1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CreatureCmd.Damage(choiceContext, Owner.Creature, DynamicVars["HpLoss"].IntValue,
            ValueProp.Unblockable | ValueProp.Unpowered, (CardModel?)null);
        await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
        await CommonActions.Draw(this, choiceContext);
    }
}
