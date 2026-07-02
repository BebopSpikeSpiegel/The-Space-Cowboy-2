using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>The first Attack you play each turn grants 1 Flow.</summary>
public class Jericho941 : SpaceCowboyRelic
{
    public override RelicRarity Rarity => RelicRarity.Common;

    private bool _triggeredThisTurn;

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (_triggeredThisTurn || cardPlay.Card.Owner != Owner || cardPlay.Card.Type != CardType.Attack)
        {
            return;
        }
        _triggeredThisTurn = true;
        Flash();
        await CommonActions.Apply<Flow>(Owner.Creature, null, 1);
    }

    public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (player == Owner)
        {
            _triggeredThisTurn = false;
        }
        return Task.CompletedTask;
    }

    public override Task BeforeCombatStart()
    {
        _triggeredThisTurn = false;
        return Task.CompletedTask;
    }
}
