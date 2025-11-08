
public static class QRDataTest
{
    public static void Run(string str, QRErrorCorrectionLevel level)
    {
        // 1. Создаём QRData из примера
        byte[] dataBytes = { 64, 196, 132, 84, 196, 196, 242, 194, 4, 132, 20, 37, 34, 16, 236, 17 };
        List<bool> bits = new List<bool>();
        foreach (byte b in dataBytes)
            for (int i = 7; i >= 0; i--)
                bits.Add((b & (1 << i)) != 0);

        var qrData = new QRData(bits, QRVersion.V2, QRErrorCorrectionLevel.H);

        // 2. Получаем блоки с EC
        var blocks = QRData.BlockedData(qrData);





        foreach (var item in QRVersionData.AllValues)
        {
            System.Diagnostics.Debug.Write(item + ") ");

            foreach (var i in item.AlignmentPatternsPositions())
            {
                System.Diagnostics.Debug.Write(i + " ");
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}

