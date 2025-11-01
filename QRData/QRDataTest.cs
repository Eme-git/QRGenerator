
public static class QRDataTest
{
    public static void Run(string str, QRVersion version)
    {
        var db = QRData.Parse(str, version);
    }
}

