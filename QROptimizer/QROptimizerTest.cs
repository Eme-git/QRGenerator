public static class QROptimizerTest
{
    public static void Run()
    {
        var opt = new QROptimizer("123HELLOкириллица007", 10);
        var result = opt.Optimize();

        System.Diagnostics.Debug.WriteLine($"Минимально: {result.Item1} бит");
        foreach (var seg in result.Item2)
        {
            string text = "???";
            try { text = "123HELLOкириллица007".Substring(seg.Item1, seg.Item2 - seg.Item1); }
            catch { }
            System.Diagnostics.Debug.WriteLine($"[{seg.Item1}..{seg.Item2}) '{text}' → {seg.Item3}");
        }
    }
}
