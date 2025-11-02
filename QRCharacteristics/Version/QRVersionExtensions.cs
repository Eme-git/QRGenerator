
public static class QRVersionExtensions
{
    public static int getBitLimit(this QRVersion version, QRErrorCorrectionLevel level) 
        => QRVersionData.Data[(int)version, (int)level];

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

        // Добавляем один терминатор (4 нуля, или меньше, если места нет — но пока 4)
        allBits.AddRange([false, false, false, false]);

        // Паддинг до кратности 8 бит (нулями)
        int padding = (8 - allBits.Count % 8) % 8;
        allBits.AddRange(Enumerable.Repeat(false, padding));

        System.Diagnostics.Debug.WriteLine($"По факту (+ терминатор + паддинг): {allBits.Count} бит");

        return allBits;
    }
}


