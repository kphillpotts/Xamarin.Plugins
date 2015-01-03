using Lamp.Plugin.Abstractions;
using System;

namespace Lamp.Plugin
{
  /// <summary>
  /// Cross platform Lamp implemenations
  /// </summary>
  public class CrossLamp
  {
    static Lazy<ILamp> Implementation = new Lazy<ILamp>(() => CreateLamp(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ILamp Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ILamp CreateLamp()
    {
#if PORTABLE
        return null;
#else
        return new LampImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
