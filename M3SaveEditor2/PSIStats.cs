using System;
using M3SaveEditor2.Properties;

namespace M3SaveEditor2;

internal class PSIStats
{
	private static string[] names = Resources.psinames.Split(new string[1] { "\r\n" }, StringSplitOptions.None);

	public static string Name(int index)
	{
		return names[index * 2 + 1].Substring(5).Replace("[ALPHA]", "α").Replace("[BETA]", "β")
			.Replace("[GAMMA]", "γ")
			.Replace("[OMEGA]", "Ω");
	}
}
