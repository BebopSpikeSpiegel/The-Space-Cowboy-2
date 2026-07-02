using System.Collections.Generic;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Rooms;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>Yeah! The bounty hunter show: gain 25 gold after each combat victory.</summary>
public class BigShot : SpaceCowboyRelic
{
    public override RelicRarity Rarity => RelicRarity.Uncommon;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Gold", 25)];

    public override async Task AfterCombatVictory(CombatRoom _)
    {
        if (Owner.Creature.IsDead)
        {
            return;
        }
        Flash();
        await PlayerCmd.GainGold(DynamicVars["Gold"].IntValue, Owner, wasStolenBack: false);
    }
}
