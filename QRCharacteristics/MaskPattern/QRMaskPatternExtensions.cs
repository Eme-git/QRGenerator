using System.Collections;

public static class QRMaskPatternExtensions
{
    public static BitArray Bit(this QRMaskPattern maskPattern) => QRMaskPatternData.Data[maskPattern].BitPattern;
    public static Func<bool, byte, byte, bool> Func(this QRMaskPattern maskPattern) => QRMaskPatternData.Data[maskPattern].Mask;
    public static IEnumerable<QRMaskPattern> GetAll()
        => [
            QRMaskPattern.Pattern000,
            QRMaskPattern.Pattern001,
            QRMaskPattern.Pattern010,
            QRMaskPattern.Pattern011,
            QRMaskPattern.Pattern100,
            QRMaskPattern.Pattern101,
            QRMaskPattern.Pattern110,
            QRMaskPattern.Pattern111
        ];
}