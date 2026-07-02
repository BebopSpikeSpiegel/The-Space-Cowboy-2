using Godot;

namespace SpaceCowboy.SpaceCowboyCode.Extensions;

//Mostly utilities to get asset paths.
//NOTE: res:// paths must use forward slashes; Path.Join emits '\' on Windows, which
//breaks Godot's asset cache lookups, so paths are joined manually here.
public static class StringExtensions
{
    private static string Join(params string[] parts) => string.Join('/', parts);

    public static string ImagePath(this string path)
    {
        return Join(MainFile.ResPath, "images", path);
    }

    public static string CardImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "card_portraits", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find card image path: " + full);
        return Join(MainFile.ResPath, "images", "card_portraits", "card.png");
    }

    public static string BigCardImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "card_portraits", "big", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find big card image path: " + full);
        return Join(MainFile.ResPath, "images", "card_portraits", "big", "card.png");
    }

    public static string PowerImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "powers", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find power image path: " + full);
        return Join(MainFile.ResPath, "images", "powers", "power.png");
    }

    public static string BigPowerImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "powers", "big", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find big power image path: " + full);
        return Join(MainFile.ResPath, "images", "powers", "big", "power.png");
    }

    public static string RelicImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "relics", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find relic image path: " + full);
        return Join(MainFile.ResPath, "images", "relics", "relic.png");
    }

    public static string BigRelicImagePath(this string path)
    {
        var full = Join(MainFile.ResPath, "images", "relics", "big", path);
        if (ResourceLoader.Exists(full)) return full;

        MainFile.Logger.Info("Could not find big relic image path: " + full);
        return Join(MainFile.ResPath, "images", "relics", "big", "relic.png");
    }

    public static string CharacterUiPath(this string path)
    {
        return Join(MainFile.ResPath, "images", "charui", path);
    }
}
