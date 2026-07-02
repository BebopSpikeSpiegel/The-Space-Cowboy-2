using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Cards.Uncommon;

public class AsteroidBlues : SpaceCowboyCard
{
    // Counts every card play this combat turn (hooks broadcast to deck copies), so at
    // OnPlay time a value of 0 means this card is the first play of the turn.
    private int _cardsPlayedThisTurn;

    public AsteroidBlues() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        WithDamage(8, 3);
        WithPower<Flow>("Flow", 2);
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        bool first = _cardsPlayedThisTurn == 0;
        await CommonActions.CardAttack(this, play.Target).Execute(choiceContext);
        if (first)
        {
            await CommonActions.ApplySelf<Flow>(this, DynamicVars["Flow"].IntValue);
        }
    }

    public override Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Owner == Owner)
        {
            _cardsPlayedThisTurn++;
        }
        return Task.CompletedTask;
    }

    public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        if (player == Owner)
        {
            _cardsPlayedThisTurn = 0;
        }
        return Task.CompletedTask;
    }

    public override Task BeforeCombatStart()
    {
        _cardsPlayedThisTurn = 0;
        return Task.CompletedTask;
    }
}
