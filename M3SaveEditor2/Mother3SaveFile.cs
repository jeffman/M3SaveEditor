using System;
using System.Globalization;
using System.IO;
using M3SaveEditor2.Properties;

namespace M3SaveEditor2;

internal class Mother3SaveFile
{
	private struct TextTable
	{
		public byte value;

		public string letter;
	}

	private const int charBase = 2210;

	private FileStream file;

	public bool IsLoaded;

	private byte[] data;

	public bool IsChanged;

	public int bank = 4;

	private TextTable[] textTable;

	public FileStream FileHandle
	{
		get
		{
			return file;
		}
		set
		{
			file = value;
			if (file != null)
			{
				LoadFile();
			}
		}
	}

	public Mother3SaveFile()
	{
		textTable = new TextTable[256];
		string[] array = Resources.texttable.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			byte b = byte.Parse(array[i].Substring(0, 2), NumberStyles.HexNumber);
			textTable[b].value = b;
			textTable[b].letter = array[i].Substring(3);
		}
	}

	private void LoadFile()
	{
		if (file != null)
		{
			if (file.Length < 65536)
			{
				throw new Exception("The file is not a battery save. Make sure you're not trying to load a save state.");
			}
			data = new byte[65536];
			file.Read(data, 0, data.Length);
			IsLoaded = true;
			IsChanged = false;
		}
	}

	public string GetString(int offset, int length)
	{
		string text = "";
		for (int i = 0; i < length; i++)
		{
			ushort num = (ushort)(data[offset + i * 2] + (data[offset + 1 + i * 2] << 8));
			if (num == ushort.MaxValue)
			{
				break;
			}
			text += textTable[(byte)num].letter;
		}
		return text;
	}

	public void SetString(int offset, string text, int length)
	{
		char[] array = text.ToCharArray();
		if (array.Length > length)
		{
			Array.Resize(ref array, length);
		}
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			flag = false;
			for (int j = 0; j < textTable.Length; j++)
			{
				if (flag)
				{
					break;
				}
				if (textTable[j].value > 0 && array[i] == textTable[j].letter[0])
				{
					data[offset + i * 2] = textTable[j].value;
					data[offset + i * 2 + 1] = 0;
					flag = true;
				}
			}
			if (!flag)
			{
				data[offset + i * 2] = 0;
				data[offset + i * 2 + 1] = 0;
			}
		}
		for (int k = array.Length; k < length; k++)
		{
			data[offset + k * 2] = byte.MaxValue;
			data[offset + k * 2 + 1] = byte.MaxValue;
		}
		IsChanged = true;
	}

	public uint GetNumber(int offset, int length)
	{
		uint num = 0u;
		for (int i = 0; i < length; i++)
		{
			num += (uint)(data[offset + i] << (i << 3));
		}
		return num;
	}

	public void SetNumber(int offset, int length, uint value)
	{
		for (int i = 0; i < length; i++)
		{
			data[offset + i] = (byte)((value >> (i << 3)) & 0xFF);
		}
		IsChanged = true;
	}

	public bool SaveExists(int slot)
	{
		return data[104 + slot * 100] != 0;
	}

	public byte GetActiveChar(int index)
	{
		return data[((bank == 4) ? 22 : 122) + index];
	}

	public void SetActiveChar(int index, byte value)
	{
		data[((bank == 4) ? 22 : 122) + index] = value;
		data[8 + (bank << 12) + index] = value;
	}

	private void RecalculateChecksums()
	{
		int num = 0;
		for (int i = 0; i < 240; i += 2)
		{
			num += data[i] + (data[i + 1] << 8);
		}
		num &= 0xFFFF;
		num ^= 0xFFFF;
		data[240] = (byte)(num & 0xFF);
		data[241] = (byte)((num >> 8) & 0xFF);
		num = 13135;
		for (int j = 16390; j < 20480; j += 2)
		{
			num += data[j] + (data[j + 1] << 8);
		}
		num &= 0xFFFF;
		num ^= 0xFFFF;
		data[16388] = (byte)(num & 0xFF);
		data[16389] = (byte)((num >> 8) & 0xFF);
		num = 13135;
		for (int k = 40966; k < 45056; k += 2)
		{
			num += data[k] + (data[k + 1] << 8);
		}
		num &= 0xFFFF;
		num ^= 0xFFFF;
		data[40964] = (byte)(num & 0xFF);
		data[40965] = (byte)((num >> 8) & 0xFF);
	}

	private void CopyBanks()
	{
		for (int i = 0; i < 4096; i++)
		{
			data[i + 4096] = data[i];
			data[i + 28672] = data[i + 16384];
			data[i + 53248] = data[i + 40960];
		}
	}

	public void Save()
	{
		RecalculateChecksums();
		CopyBanks();
		file.Seek(0L, SeekOrigin.Begin);
		file.Write(data, 0, data.Length);
		IsChanged = false;
	}

	public string GetName(int index)
	{
		if (index == -1)
		{
			return "(None)";
		}
		return GetString(2210 + index * 108 + (bank << 12), 8);
	}

	public void SetName(int index, string value)
	{
		SetString(2210 + index * 108 + (bank << 12), value, 8);
		if (index == GetActiveChar(0) - 1)
		{
			SetString((bank == 4) ? 62 : 162, value, 8);
			data[(bank == 4) ? 78 : 178] = GetLevel(index);
		}
		if (index == 12)
		{
			SetString(1690 + (bank << 12), value, 8);
		}
	}

	public byte GetLevel(int index)
	{
		return (byte)GetNumber(2226 + index * 108 + (bank << 12), 1);
	}

	public void SetLevel(int index, byte value)
	{
		SetNumber(2226 + index * 108 + (bank << 12), 1, value);
	}

	public uint GetExp(int index)
	{
		return GetNumber(2228 + index * 108 + (bank << 12), 4);
	}

	public void SetExp(int index, uint value)
	{
		SetNumber(2228 + index * 108 + (bank << 12), 4, value);
	}

	public ushort GetCurHP(int index)
	{
		return (ushort)GetNumber(2232 + index * 108 + (bank << 12), 2);
	}

	public void SetCurHP(int index, ushort value)
	{
		SetNumber(2232 + index * 108 + (bank << 12), 2, value);
	}

	public ushort GetCurPP(int index)
	{
		return (ushort)GetNumber(2236 + index * 108 + (bank << 12), 2);
	}

	public void SetCurPP(int index, ushort value)
	{
		SetNumber(2236 + index * 108 + (bank << 12), 2, value);
	}

	public ushort GetMaxHP(int index)
	{
		return (ushort)GetNumber(2240 + index * 108 + (bank << 12), 2);
	}

	public void SetMaxHP(int index, ushort value)
	{
		SetNumber(2240 + index * 108 + (bank << 12), 2, value);
	}

	public ushort GetMaxPP(int index)
	{
		return (ushort)GetNumber(2244 + index * 108 + (bank << 12), 2);
	}

	public void SetMaxPP(int index, ushort value)
	{
		SetNumber(2244 + index * 108 + (bank << 12), 2, value);
	}

	public byte GetOffense(int index)
	{
		return (byte)GetNumber(2248 + index * 108 + (bank << 12), 1);
	}

	public void SetOffense(int index, byte value)
	{
		SetNumber(2248 + index * 108 + (bank << 12), 1, value);
	}

	public byte GetDefense(int index)
	{
		return (byte)GetNumber(2249 + index * 108 + (bank << 12), 1);
	}

	public void SetDefense(int index, byte value)
	{
		SetNumber(2249 + index * 108 + (bank << 12), 1, value);
	}

	public byte GetIQ(int index)
	{
		return (byte)GetNumber(2250 + index * 108 + (bank << 12), 1);
	}

	public void SetIQ(int index, byte value)
	{
		SetNumber(2250 + index * 108 + (bank << 12), 1, value);
	}

	public byte GetSpeed(int index)
	{
		return (byte)GetNumber(2251 + index * 108 + (bank << 12), 1);
	}

	public void SetSpeed(int index, byte value)
	{
		SetNumber(2251 + index * 108 + (bank << 12), 1, value);
	}

	public byte GetEquipment(int index, int type)
	{
		return (byte)GetNumber(2260 + index * 108 + (bank << 12) + type, 1);
	}

	public void SetEquipment(int index, int type, byte value)
	{
		SetNumber(2260 + index * 108 + (bank << 12) + type, 1, value);
	}

	public byte GetItem(int index, int itemIndex)
	{
		return (byte)GetNumber(2268 + index * 108 + (bank << 12) + itemIndex, 1);
	}

	public void SetItem(int index, int itemIndex, byte value)
	{
		SetNumber(2268 + index * 108 + (bank << 12) + itemIndex, 1, value);
	}

	public bool GetPSIFlag(int index, int flagNum)
	{
		byte b = data[1832 + index * 26 + (flagNum >> 3) + (bank << 12)];
		flagNum &= 7;
		b = (byte)(b >> flagNum);
		b &= 1;
		return b == 1;
	}

	public void SetPSIFlag(int index, int flagNum, bool value)
	{
		byte b = data[1832 + index * 26 + (flagNum >> 3) + (bank << 12)];
		byte b2 = (byte)(1 << (flagNum & 7));
		b2 ^= 0xFF;
		b &= b2;
		b2 = (byte)(value ? 1u : 0u);
		b2 = (byte)(b2 << (flagNum & 7));
		b |= b2;
		SetNumber(1832 + index * 26 + (flagNum >> 3) + (bank << 12), 1, b);
	}

	public byte GetItemGuy(int itemNum)
	{
		return (byte)GetNumber(280 + itemNum + (bank << 12), 1);
	}

	public void SetItemGuy(int itemNum, byte value)
	{
		SetNumber(280 + itemNum + (bank << 12), 1, value);
	}

	public string GetHinawaName()
	{
		return GetString(1674 + (bank << 12), 8);
	}

	public void SetHinawaName(string value)
	{
		SetString(1674 + (bank << 12), value, 8);
	}

	public string GetFavFood()
	{
		return GetString(1706 + (bank << 12), 9);
	}

	public void SetFavFood(string value)
	{
		SetString(1706 + (bank << 12), value, 9);
	}

	public string GetFavThing()
	{
		return GetString(1724 + (bank << 12), 9);
	}

	public void SetFavThing(string value)
	{
		SetString(1724 + (bank << 12), value, 9);
	}

	public string GetPlayerName()
	{
		return GetString(1742 + (bank << 12), 25);
	}

	public void SetPlayerName(string value)
	{
		SetString(1742 + (bank << 12), value, 25);
	}
}
