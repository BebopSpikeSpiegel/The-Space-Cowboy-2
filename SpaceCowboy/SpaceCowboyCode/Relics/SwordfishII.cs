using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>His ship, his freedom: +1 Energy each turn and 2 Flow at the start of combat.</summary>
public class SwordfishII : SpaceCowboyRelic
{
    // STS2 has no "Boss" rarity; Ancient is the boss-tier pool (relics from Ancients).
    public override RelicRarity Rarity => RelicRarity.Ancient;

    public override decimal ModifyMaxEnergy(Player player, decimal energy)
    {
        return player == Owner ? energy + 1 : energy;
    }

    public override async Task BeforeCombatStartLate()
    {
        Flash();
        await CommonActions.Apply<Flow>(Owner.Creature, null, 2);
    }
}
