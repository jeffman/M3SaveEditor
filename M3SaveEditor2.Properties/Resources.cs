using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace M3SaveEditor2.Properties;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object.ReferenceEquals(resourceMan, null))
			{
				ResourceManager resourceManager = new ResourceManager("M3SaveEditor2.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap disk
	{
		get
		{
			object obj = ResourceManager.GetObject("disk", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap folder
	{
		get
		{
			object obj = ResourceManager.GetObject("folder", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static byte[] itemdata
	{
		get
		{
			object obj = ResourceManager.GetObject("itemdata", resourceCulture);
			return (byte[])obj;
		}
	}

	internal static string itemnames => ResourceManager.GetString("itemnames", resourceCulture);

	internal static string psinames => ResourceManager.GetString("psinames", resourceCulture);

	internal static string texttable => ResourceManager.GetString("texttable", resourceCulture);

	internal Resources()
	{
	}
}
