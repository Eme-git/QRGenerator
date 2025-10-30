public class QROptimizer
{
    private readonly int _version;
    private readonly string _input;

    public enum Mode { Numeric, Alphanumeric, Byte, Kanji }

    public QROptimizer(string input, int version)
    {
        _input = input;
        _version = version;
    }

    public (int totalBits, List<(int start, int end, Mode mode)> segments) Optimize()
    {
        int n = _input.Length;
        var dp = new int[n + 1];
        var prev = new (int idx, Mode mode)[n + 1];
        Array.Fill(dp, int.MaxValue / 2);
        dp[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            foreach (var mode in Enum.GetValues(typeof(Mode)).Cast<Mode>())
            {
                for (int j = 0; j < i; j++)
                {
                    if (!CanEncode(_input, j, i, mode)) continue;

                    int cost = GetCost(_input, j, i, mode, _version);
                    if (dp[j] + cost < dp[i])
                    {
                        dp[i] = dp[j] + cost;
                        prev[i] = (j, mode);
                    }
                }
            }
        }

        var segments = new List<(int start, int end, Mode mode)>();
        int cur = n;
        while (cur > 0)
        {
            var (prevIdx, mode) = prev[cur];
            segments.Add((prevIdx, cur, mode));
            cur = prevIdx;
        }
        segments.Reverse();

        return (dp[n], segments);
    }

    private bool CanEncode(string s, int start, int end, Mode mode) => mode switch
    {
        Mode.Numeric => s[start..end].All(char.IsDigit),
        Mode.Alphanumeric => s[start..end].All(c => "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:".Contains(c)),
        Mode.Byte => true,
        Mode.Kanji => s[start..end].All(IsKanji),
        _ => false
    };

    private bool IsKanji(char c) => c >= 0x4E00 && c <= 0x9FFF;

    private int GetCost(string s, int start, int end, Mode mode, int version)
    {
        int L = end - start;
        if (L == 0) return 0;

        int dataBits = mode switch
        {
            Mode.Numeric => (int)Math.Ceiling(L * 10.0 / 3),
            Mode.Alphanumeric => (int)Math.Ceiling(L * 11.0 / 2),
            Mode.Byte => L * 8,
            Mode.Kanji => L * 13,
            _ => 0
        };

        int countBits = GetCountBits(mode, version);
        return 4 + countBits + dataBits;
    }

    private int GetCountBits(Mode mode, int version) => (mode, version) switch
    {
        (Mode.Numeric, <= 9) => 10,
        (Mode.Numeric, <= 26) => 12,
        (Mode.Numeric, _) => 14,

        (Mode.Alphanumeric, <= 9) => 9,
        (Mode.Alphanumeric, <= 26) => 11,
        (Mode.Alphanumeric, _) => 13,

        (Mode.Byte, <= 9) => 8,
        (Mode.Byte, _) => 16,

        (Mode.Kanji, <= 9) => 8,
        (Mode.Kanji, <= 26) => 10,
        (Mode.Kanji, _) => 12,

        _ => 0
    };
}