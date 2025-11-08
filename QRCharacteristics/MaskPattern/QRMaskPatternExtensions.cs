using System.Collections;

public static class QRMaskPatternExtensions
{
    public static List<bool> Bit(this QRMaskPattern maskPattern) => QRMaskPatternData.Data[maskPattern].BitPattern;
    public static Func<bool, byte, byte, bool> Func(this QRMaskPattern maskPattern) => QRMaskPatternData.Data[maskPattern].Mask;

    public static short MaskCodeAndCorrectionLevel(this QRMaskPattern pattern, QRErrorCorrectionLevel level)
        => QRMaskPatternData.Table[(pattern, level)];
}