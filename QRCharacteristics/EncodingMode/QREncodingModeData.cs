using System.Collections;
using System.Text;
using System.Threading.Tasks;

public static class QREncodingModeData
{
    public static string AlphanumericChars { get; private set; } = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";
    public static List<QREncodingMode> AllValues { get; private set; } 
        = Enum.GetValues(typeof(QREncodingMode)).Cast<QREncodingMode>().ToList();

    public static Dictionary<QREncodingMode, (List<bool> BitPattern, Func<string, List<bool>> Encode)> Data { get; private set; } =
        new Dictionary<QREncodingMode, (List<bool> BitPattern, Func<string, List<bool>> Encode)>
        {
            {
                QREncodingMode.Numeric,
                (
                    [false, false, false, true],
                    EncodeNumeric
                )
            },
            {
                QREncodingMode.Alphanumeric,
                (
                    [false, false, true, false],
                    EncodeAlphanumeric
                )
            },
            {
                QREncodingMode.Byte,
                (
                    [false, true, false, false],
                    EncodeByte
                )
            },
            {
                QREncodingMode.Kanji,
                (
                    [true, false, false, false],
                    EncodeKanji
                )
            },
        };

    private static List<bool> EncodeNumeric(string text)
    {
        var bits = new List<bool>();

        for (int i = 0; i < text.Length; i += 3)
        {
            int remaining = text.Length - i;
            if (remaining >= 3)
            {
                // Группа из 3 цифр -> 10 бит
                int value = int.Parse(text.Substring(i, 3));
                bits.AddRange(IntToBits(value, 10));
            }
            else if (remaining == 2)
            {
                // Группа из 2 цифр -> 7 бит
                int value = int.Parse(text.Substring(i, 2));
                bits.AddRange(IntToBits(value, 7));
            }
            else if (remaining == 1)
            {
                // Одна цифра -> 4 бита
                int value = int.Parse(text.Substring(i, 1));
                bits.AddRange(IntToBits(value, 4));
            }
        }

        return bits;
    }

    private static List<bool> EncodeAlphanumeric(string text)
    {
        var bits = new List<bool>();
        
        // Обрабатываем по 2 символа за раз
        for (int i = 0; i < text.Length; i += 2)
        {
            int remaining = text.Length - i;
            if (remaining >= 2)
            {
                // Группа из 2 символов -> 11 бит
                int index1 = AlphanumericChars.IndexOf(text[i]);
                int index2 = AlphanumericChars.IndexOf(text[i + 1]);
                int value = index1 * 45 + index2;
                bits.AddRange(IntToBits(value, 11));
            }
            else
            {
                // Один символ -> 6 бит
                int index = AlphanumericChars.IndexOf(text[i]);
                bits.AddRange(IntToBits(index, 6));
            }
        }

        return bits;
    }

    private static List<bool> EncodeByte(string text)
    {
        var bits = new List<bool>();
        var bytes = System.Text.Encoding.UTF8.GetBytes(text);

        foreach (byte b in bytes)
        {
            bits.AddRange(IntToBits(b, 8));
        }

        return bits;
    }

    private static List<bool> EncodeKanji(string text)
    {
        var bits = new List<bool>();

        var shiftJis = Encoding.GetEncoding("shift_jis");
        byte[] bytes = shiftJis.GetBytes(text);

        for (int i = 0; i < bytes.Length; i += 2)
        {
            byte high = bytes[i];
            byte low = bytes[i + 1];
            int value = (high << 8) | low; 

            if (value >= 0x8140 && value <= 0x9FFC)
            {
                value -= 0x8140;
            }
            else if (value >= 0xE040 && value <= 0xEBBF)
            {
                value -= 0xC140;
            }

            bits.AddRange(IntToBits(value, 13));
        }

        return bits;
    }

    public static List<bool> IntToBits(int value, int bitCount)
    {
        var bits = new bool[bitCount];

        for (int i = 0; i < bitCount; i++)
        {
            bits[bitCount - 1 - i] = (value & (1 << i)) != 0;
        }
        return bits.ToList();
    }
}