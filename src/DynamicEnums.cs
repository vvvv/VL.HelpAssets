using System.Reactive.Linq;
using VL.Core.CompilerServices;

namespace System.Help;

static class Helper
{
    public static IReadOnlyDictionary<string, object> GetFiles(string path)
    {
        var basepath = AppHost.Current.GetPackagePath("VL.HelpAssets");

        var entries = new Dictionary<string, object>();

        foreach (var entry in Directory.GetFiles(Path.Combine(basepath, path)))
        {
            entries.Add(Path.GetFileName(entry), entry);
        }

        return entries;
    }
}

[Serializable]
public class SoundAsset : DynamicEnumBase<SoundAsset, SoundAssetDefinition>
{
    public SoundAsset(string value) : base(value) { }
    [CreateDefault] public static SoundAsset CreateDefault() => CreateDefaultBase();
}

public class SoundAssetDefinition : DynamicEnumDefinitionBase<SoundAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("sounds");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}

[Serializable]
public class ImageAsset : DynamicEnumBase<ImageAsset, ImageAssetDefinition>
{
    public ImageAsset(string value) : base(value) { }
    [CreateDefault] public static ImageAsset CreateDefault() => CreateDefaultBase();
}

public class ImageAssetDefinition : DynamicEnumDefinitionBase<ImageAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("images");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}