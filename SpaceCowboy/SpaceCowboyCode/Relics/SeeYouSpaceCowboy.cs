using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models.Powers;

namespace SpaceCowboy.SpaceCowboyCode.Relics;

/// <summary>You're gonna carry that weight: gain 1 Buffer at the start of each combat.</summary>
public class SeeYouSpaceCowboy : SpaceCowboyRelic
{
    public override RelicRarity Rarity => RelicRarity.Rare;

    public override async Task BeforeCombatStartLate()
    {
        Flash();
        await CommonActions.Apply<BufferPower>(Owner.Creature, null, 1);
    }
}
