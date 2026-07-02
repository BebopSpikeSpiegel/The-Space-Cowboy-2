using System.Collections.Generic;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using SpaceCowboy.SpaceCowboyCode.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>
/// Starter relic: light one up before the fight. Gain 2 Flow at the start of each combat.
/// </summary>
public class Marlboro : SpaceCowboyRelic
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DynamicVar("Flow", 2)];

    public override async Task BeforeCombatStartLate()
    {
        Flash();
        await CommonActions.Apply<Flow>(Owner.Creature, null, DynamicVars["Flow"].IntValue);
    }
}
