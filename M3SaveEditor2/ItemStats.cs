using System;
using M3SaveEditor2.Properties;

namespace M3SaveEditor2;

internal class ItemStats
{
	private static byte[] data = Resources.itemdata;

	private static string[] names = Resources.itemnames.Split(new string[1] { "\r\n" }, StringSplitOptions.None);

	public static int MaxHP(int index)
	{
		int num = data[16 + index * 108];
		num += data[17 + index * 108] << 8;
		num += data[18 + index * 108] << 16;
		return num + (data[19 + index * 108] << 24);
	}

	public static short MaxPP(int index)
	{
		short num = data[20 + index * 108];
		return (short)(num + (short)(data[21 + index * 108] << 8));
	}

	public static sbyte Offense(int index)
	{
		return (sbyte)data[24 + index * 108];
	}

	public static sbyte Defense(int index)
	{
		return (sbyte)data[25 + index * 108];
	}

	public static sbyte IQ(int index)
	{
		return (sbyte)data[26 + index * 108];
	}

	public static sbyte Speed(int index)
	{
		return (sbyte)data[27 + index * 108];
	}

	public static string Name(int index)
	{
		return names[index * 2 + 1].Substring(8);
	}
}
