using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class CallMeCallMe : SpaceCowboyCard
{
    public CallMeCallMe() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        WithPower<Flow>("Flow", 1, 1);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        var chosen = await CommonActions.SelectSingleCard(this, SelectionScreenPrompt, choiceContext, PileType.Discard);
        if (chosen != null)
        {
            await CardPileCmd.Add(chosen, PileType.Hand);
        }
        await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
    }
}
