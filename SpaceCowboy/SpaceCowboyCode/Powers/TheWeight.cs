using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.ValueProps;

namespace SpaceCowboy.SpaceCowboyCode.Powers;

/// <summary>
/// The Weight (Bang.'s recoil): at the start of your next turn, lose Amount HP, then
/// the power removes itself. "You're gonna carry that weight."
/// </summary>
public class TheWeight : SpaceCowboyPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (player.Creature != Owner)
        {
            return;
        }
        await CreatureCmd.Damage(choiceContext, Owner, Amount, ValueProp.Unblockable | ValueProp.Unpowered,
            (MegaCrit.Sts2.Core.Models.CardModel?)null);
        await PowerCmd.Remove(this);
    }
}
