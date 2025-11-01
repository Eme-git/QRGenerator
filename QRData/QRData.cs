using System;
using static System.Net.Mime.MediaTypeNames;

public class QRData
{
    public List<bool> Data { get; private set; }

    public QRData(List<bool> Data)
    {
        this.Data = Data;
    }

    public static QRData Parse(string parseString, QRVersion version)
    {
        int n = parseString.Length;
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
                    if (!mode.CanEncode(parseString, j, i)) continue;

                    int cost = mode.GetCost(parseString, j, i, version);
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

        foreach (var (start, end, mode) in segments)
        {
            string text = parseString[start..end];

            // Добавляем режим + счётчик + данные
            allBits.AddRange(mode.Bit());
            allBits.AddRange(QREncodingModeData.IntToBits(text.Length, mode.GetCountBits(version)));
            var dataBits = mode.Encode()(text);
            allBits.AddRange(dataBits);

            // Тест для сегмента
            int expectedCost = mode.GetCost(parseString, start, end, version);
            int actualSegmentBits = 4 + mode.GetCountBits(version) + dataBits.Count;
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

        return new QRData(allBits);
    }

    public static List<bool> Encode(int totalBits, string encodeString, int start, int end, QREncodingMode mode, QRVersion version)
    {
        var bitList = new List<bool>(totalBits);

        string segmentText = encodeString[start..end];
        int charCount = segmentText.Length;

        // 1. Добавляем индикатор режима (4 бита)
        bitList.AddRange(mode.Bit());

        
        // 2. Добавляем счетчик символов
        bitList.AddRange(QREncodingModeData.IntToBits(charCount, QREncodingModeExtensions.GetCountBits(mode, version)));

        // 3. Добавляем данные
        bitList.AddRange(mode.Encode()(segmentText));

        return bitList;
    }

    public static void Test(int bitCount, string str, int begin, int end, QREncodingMode mode, QRVersion version)
    {
        var cost = mode.GetCost(str, begin, end, version);
        System.Diagnostics.Debug.WriteLine(
            $"[{begin}..{end}) '{str.Substring(begin, end - begin)}' → {mode}({cost} → {bitCount})");
    }
}

