using System.Collections;
using System.Text;

public static class QREncodingModeExtensions
{
    public static bool CanEncode(this QREncodingMode mode, string s, int begin, int end)
    {
        switch (mode)
        {
            case QREncodingMode.Numeric:
                for (; begin < end; ++begin)
                    if (!char.IsDigit(s[begin]))
                        return false;
                return true;

            case QREncodingMode.Alphanumeric:
                for (; begin < end; ++begin)
                    if (!QREncodingModeData.AlphanumericChars.Contains(s[begin]))
                        return false;
                return true;

            case QREncodingMode.Byte:
                return true;

            case QREncodingMode.Kanji:
                for (; begin < end; ++begin)
                    if (!(0x4E00 <= s[begin] && s[begin] <= 0x9FFF))  // CJK Unified Ideographs
                        return false;
                return true;

            default:
                return false;
        }
    }

    public static int GetCost(this QREncodingMode mode, string s, int start, int end, QRVersion version)
    {
        int L = end - start;
        if (L == 0) return 0;

        int dataBits = mode switch
        {
            QREncodingMode.Numeric => (int)Math.Ceiling(L * 10.0 / 3),
            QREncodingMode.Alphanumeric => (int)Math.Ceiling(L * 11.0 / 2),
            QREncodingMode.Byte => Encoding.UTF8.GetByteCount(s[start..end]) * 8,
            QREncodingMode.Kanji => L * 13,
            _ => 0
        };

        int countBits = GetCountBits(mode, version);
        return 4 + countBits + dataBits;
    }

    public static int GetCountBits(this QREncodingMode mode, QRVersion version) => (mode, (int)version) switch
    {
        (QREncodingMode.Numeric, <= 9) => 10,
        (QREncodingMode.Numeric, <= 26) => 12,
        (QREncodingMode.Numeric, _) => 14,

        (QREncodingMode.Alphanumeric, <= 9) => 9,
        (QREncodingMode.Alphanumeric, <= 26) => 11,
        (QREncodingMode.Alphanumeric, _) => 13,

        (QREncodingMode.Byte, <= 9) => 8,
        (QREncodingMode.Byte, _) => 16,

        (QREncodingMode.Kanji, <= 9) => 8,
        (QREncodingMode.Kanji, <= 26) => 10,
        (QREncodingMode.Kanji, _) => 12,

        _ => 0
    };

    public static List<bool> Encode(this QREncodingMode mode, string data, QRVersion version)
    {
        var bitList = new List<bool>();

        // 1. Добавляем индикатор режима (4 бита)
        bitList.AddRange(mode.Bit());

        // 2. Добавляем счетчик символов
        int count;
        if (mode == QREncodingMode.Byte)
            count = Encoding.UTF8.GetByteCount(data);
        else if (mode == QREncodingMode.Kanji)
            count = data.Length; 
        else
            count = data.Length;
        bitList.AddRange(QREncodingModeData.IntToBits(count, GetCountBits(mode, version)));

        // 3. Добавляем данные
        bitList.AddRange(mode.Encode()(data));

        return bitList;
    }

    public static List<bool> Bit(this QREncodingMode mode) => QREncodingModeData.Data[mode].BitPattern;
    public static Func<string, List<bool>> Encode(this QREncodingMode mode) => QREncodingModeData.Data[mode].Encode;
}
