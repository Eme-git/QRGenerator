public class QRErrorCorrectionLevelExtensions
{
    public static List<QRErrorCorrectionLevel> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRErrorCorrectionLevel)).Cast<QRErrorCorrectionLevel>().ToList();

    public static List<byte> GeneratingPolynomial(int blockCount)
        => QRErrorCorrectionLevelData.GeneratingPolynomial[blockCount];
}

