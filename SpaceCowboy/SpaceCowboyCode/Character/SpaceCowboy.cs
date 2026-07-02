using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using SpaceCowboy.SpaceCowboyCode.Extensions;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.Nodes.Combat;
using SpaceCowboy.SpaceCowboyCode.Cards.Basic;
using SpaceCowboy.SpaceCowboyCode.Relics;

namespace SpaceCowboy.SpaceCowboyCode.Character;

public class SpaceCowboy : PlaceholderCharacterModel
{
    public const string CharacterId = "SpaceCowboy";

    // STS1 Spike blue (RGB 0, 39, 127).
    public static readonly Color Color = new("00277f");

    public override Color NameColor => Color;
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 80;

    public override IEnumerable<CardModel> StartingDeck => [
        ModelDb.Card<StraightLead>(),
        ModelDb.Card<StraightLead>(),
        ModelDb.Card<StraightLead>(),
        ModelDb.Card<StraightLead>(),
        ModelDb.Card<Dodge>(),
        ModelDb.Card<Dodge>(),
        ModelDb.Card<Dodge>(),
        ModelDb.Card<Shoot>(),
        ModelDb.Card<JeetKuneDo>(),
        ModelDb.Card<JeetKuneDo>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<Marlboro>()
    ];
    
    public override CardPoolModel CardPool => ModelDb.CardPool<SpaceCowboyCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<SpaceCowboyRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<SpaceCowboyPotionPool>();
    
    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets. 
        These are just some of the simplest assets, given some placeholders to differentiate your character with. 
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }
    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();

    // Static combat sprite (STS1 parity): BaseLib's NCreatureVisuals factory builds the
    // full creature node (bounds/markers) from a single texture — no Spine rig needed.
    public override NCreatureVisuals? CreateCustomVisuals()
    {
        return NodeFactory<NCreatureVisuals>.CreateFromResource("char_spike.png".ImagePath());
    }

    // Gun-smoke character select background (scene shipped in our pck via MegaDot export).
    public override string CustomCharacterSelectBg => $"{MainFile.ResPath}/scenes/char_select_bg_spacecowboy.tscn";
}