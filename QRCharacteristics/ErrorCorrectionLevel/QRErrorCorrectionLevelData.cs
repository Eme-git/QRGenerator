
public class QRErrorCorrectionLevelData
{
    public static List<QRErrorCorrectionLevel> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRErrorCorrectionLevel)).Cast<QRErrorCorrectionLevel>().ToList();
}

