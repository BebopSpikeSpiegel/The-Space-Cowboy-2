using BaseLib.Abstracts;
using SpaceCowboy.SpaceCowboyCode.Extensions;
using Godot;

namespace SpaceCowboy.SpaceCowboyCode.Character;

public class SpaceCowboyPotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => SpaceCowboy.Color;
    

    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}