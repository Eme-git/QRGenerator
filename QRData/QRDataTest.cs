
public static class QRDataTest
{
    public static void Run(string str, QRErrorCorrectionLevel level)
    {
        var db = QRData.Parse(str, level);
    }
}

