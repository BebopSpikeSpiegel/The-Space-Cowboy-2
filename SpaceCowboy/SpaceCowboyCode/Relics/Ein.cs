using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>A data dog, much smarter than he looks: draw 1 extra card on your first turn.</summary>
public class Ein : SpaceCowboyRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (player != Owner || player.PlayerCombatState.TurnNumber != 1)
        {
            return;
        }
        Flash();
        await CardPileCmd.Draw(choiceContext, Owner);
    }
}
