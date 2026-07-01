using BaseLib.Abstracts;
using BaseLib.Utils;
using SpaceCowboy.SpaceCowboyCode.Character;

namespace SpaceCowboy.SpaceCowboyCode.Potions;

[Pool(typeof(SpaceCowboyPotionPool))]
public abstract class SpaceCowboyPotion : CustomPotionModel;