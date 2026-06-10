using System.Reactive.Linq;
using VL.Core.CompilerServices;

namespace System.Help;

static class Helper
{
    public static IReadOnlyDictionary<string, object> GetFiles(string path)
    {
        var basepath = AppHost.Global.GetPackagePath("VL.HelpAssets");

        var entries = new Dictionary<string, object>();

        foreach (var entry in Directory.GetFiles(Path.Combine(basepath, path)))
        {
            entries.Add(Path.GetFileName(entry), entry);
        }

        return entries;
    }

    public static IReadOnlyDictionary<string, object> GetDirectories(string path)
    {
        var basepath = AppHost.Global.GetPackagePath("VL.HelpAssets");

        var entries = new Dictionary<string, object>();

        foreach (var entry in Directory.GetDirectories(Path.Combine(basepath, path)))
        {
            entries.Add(Path.GetFileName(entry), entry);
        }

        return entries;
    }
}

[Serializable]
public class AudioAsset : DynamicEnumBase<AudioAsset, AudioAssetDefinition>
{
    public AudioAsset(string value) : base(value) { }
    [CreateDefault] public static AudioAsset CreateDefault() => CreateDefaultBase();
}

public class AudioAssetDefinition : DynamicEnumDefinitionBase<AudioAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("assets\\audio");
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
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("assets\\images");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}

[Serializable]
public class MiscAsset : DynamicEnumBase<MiscAsset, MiscAssetDefinition>
{
    public MiscAsset(string value) : base(value) { }
    [CreateDefault] public static MiscAsset CreateDefault() => CreateDefaultBase();
}

public class MiscAssetDefinition : DynamicEnumDefinitionBase<MiscAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("assets\\misc");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}

[Serializable]
public class ModelAsset : DynamicEnumBase<ModelAsset, ModelAssetDefinition>
{
    public ModelAsset(string value) : base(value) { }
    [CreateDefault] public static ModelAsset CreateDefault() => CreateDefaultBase();
}

public class ModelAssetDefinition : DynamicEnumDefinitionBase<ModelAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("assets\\models");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}

[Serializable]
public class SequenceAsset : DynamicEnumBase<SequenceAsset, SequenceAssetDefinition>
{
    public SequenceAsset(string value) : base(value) { }
    [CreateDefault] public static SequenceAsset CreateDefault() => CreateDefaultBase();
}

public class SequenceAssetDefinition : DynamicEnumDefinitionBase<SequenceAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetDirectories("assets\\sequences");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}

[Serializable]
public class VideoAsset : DynamicEnumBase<VideoAsset, VideoAssetDefinition>
{
    public VideoAsset(string value) : base(value) { }
    [CreateDefault] public static VideoAsset CreateDefault() => CreateDefaultBase();
}

public class VideoAssetDefinition : DynamicEnumDefinitionBase<VideoAssetDefinition>
{
    protected override IReadOnlyDictionary<string, object> GetEntries() => Helper.GetFiles("assets\\videos");
    protected override IObservable<object> GetEntriesChangedObservable() => Observable.Empty<object>();
}