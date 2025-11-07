
public static class QRVersionExtensions
{
    public static int BitLimit(this QRVersion version, QRErrorCorrectionLevel level) 
        => QRVersionData.Data[(version, level)].BitLimit;

    public static int BlockCount(this QRVersion version, QRErrorCorrectionLevel level)
        => QRVersionData.Data[(version, level)].BlockCount;

    public static int CorrectionByte(this QRVersion version, QRErrorCorrectionLevel level)
        => QRVersionData.Data[(version, level)].CorrectionByte;

    public static byte GaloisField(int index) => QRVersionData.GaloisField[index];

    public static byte InverseGaloisField(int index) => QRVersionData.InverseGaloisField[index];

    public static byte Multiply(byte a, byte b)
    {
        if (a == 0 || b == 0) return 0;
        int logA = GaloisField(a);
        int logB = GaloisField(b);
        int logResult = (logA + logB) % 255;
        return InverseGaloisField(logResult);
    }

    public static List<bool> Parse(this QRVersion version, string data)
    {
        int n = data.Length;
        var dp = new int[n + 1];
        var prev = new (int idx, QREncodingMode mode)[n + 1];
        Array.Fill(dp, int.MaxValue / 2);
        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            foreach (var mode in QREncodingModeData.AllValues)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!mode.CanEncode(data, j, i)) continue;

                    int cost = mode.GetCost(data, j, i, version);
                    if (dp[j] + cost < dp[i])
                    {
                        dp[i] = dp[j] + cost;
                        prev[i] = (j, mode);
                    }
                }
            }
        }

        var allBits = new List<bool>();
        var segments = new List<(int start, int end, QREncodingMode mode)>();
        int cur = n;
        while (cur > 0)
        {
            var (prevIdx, mode) = prev[cur];
            segments.Add((prevIdx, cur, mode));
            cur = prevIdx;
        }
        segments.Reverse();

        System.Diagnostics.Debug.WriteLine( "==========================" + version + 
                                            "\n" + data);
        foreach (var (start, end, mode) in segments)
        {
            string text = data[start..end];

            // Добавляем режим + счётчик + данные
            var dataBits = mode.Encode(text, version);
            allBits.AddRange(dataBits);

            // Тест для сегмента
            int expectedCost = mode.GetCost(data, start, end, version);
            int actualSegmentBits = dataBits.Count;
            System.Diagnostics.Debug.WriteLine(
                $"[{start}..{end}) '{text}' → {mode}({expectedCost} → {actualSegmentBits})");
        }
        System.Diagnostics.Debug.WriteLine($"Минимально: {dp[n]} бит");
        System.Diagnostics.Debug.WriteLine($"По факту: {allBits.Count} бит");

        return allBits;
    }
}


