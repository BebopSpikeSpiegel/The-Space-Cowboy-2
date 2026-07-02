using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Common;

public class Rain : SpaceCowboyCard
{
    public Rain() : base(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        WithBlock(7, 2);
        WithVar("MaxSpend", 3, 1);
        WithVar("PerFlow", 3);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await CommonActions.CardBlock(this, play);
        int spent = await Flow.Spend(choiceContext, Owner.Creature, DynamicVars["MaxSpend"].IntValue);
        if (spent > 0)
        {
            await CreatureCmd.GainBlock(Owner.Creature, spent * DynamicVars["PerFlow"].IntValue,
                MegaCrit.Sts2.Core.ValueProps.ValueProp.Move, play, fast: false);
        }
    }
}
