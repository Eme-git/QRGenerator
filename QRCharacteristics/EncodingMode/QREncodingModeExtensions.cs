public static class QREncodingModeExtensions
{
    private static string AlphanumericChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";

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
                    if (!AlphanumericChars.Contains(s[begin]))
                        return false;
                return true;

            case QREncodingMode.Byte:
                return true;

            case QREncodingMode.Kanji:
                for (; begin < end; ++begin)
                    if (!(0x4E00 <= s[begin] && s[begin] <= 0x9FFF))
                        return false;
                return true;

            default:
                return false;
        }
    }

    public static IEnumerable<QREncodingMode> GetAll()
        => [
            QREncodingMode.Numeric,
            QREncodingMode.Alphanumeric,
            QREncodingMode.Byte,
            QREncodingMode.Kanji,
        ];
}
