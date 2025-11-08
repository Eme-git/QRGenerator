using System.Collections;

public static class QRMaskPatternData
{
    public static List<QRMaskPattern> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRMaskPattern)).Cast<QRMaskPattern>().ToList();

    public static Dictionary<QRMaskPattern, (List<bool> BitPattern, Func<bool, byte, byte, bool> Mask)> Data { get; private set; } =
        new Dictionary<QRMaskPattern, (List<bool>, Func<bool, byte, byte, bool>)>
        {
            {
                QRMaskPattern.Pattern0,
                (
                    [false, false, false],
                    (value, i, j) => value ^ ((j + i) % 2 == 0) // (X + Y) % 2
                )
            },
            {
                QRMaskPattern.Pattern1,
                (
                    [false, false, true],
                    (value, i, j) => value ^ (i % 2 == 0) // Y % 2
                )
            },
            {
                QRMaskPattern.Pattern2,
                (
                    [false, true, false],
                    (value, i, j) => value ^ (j % 3 == 0) // X % 3
                )
            },
            {
                QRMaskPattern.Pattern3,
                (
                    [false, true, true],
                    (value, i, j) => value ^ ((j + i) % 3 == 0) // (X + Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern4,
                (
                    [true, false, false],
                    (value, i, j) => value ^ ((j / 3 + i / 2) % 2 == 0) // (X / 3 + Y / 2) % 2
                )
            },
            {
                QRMaskPattern.Pattern5,
                (
                    [true, false, true],
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) == 0) // (X * Y) % 2 + (X * Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern6,
                (
                    [true, true, false],
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) % 2 == 0) // ((X * Y) % 2 + (X * Y) % 3) % 2
                )
            },
            {
                QRMaskPattern.Pattern7,
                (
                    [true, true, true],
                    (value, i, j) => value ^ (((j * i) % 3 + (j + i) % 2) % 2 == 0) // ((X * Y) % 3 + (X + Y) % 2) % 2
                )
            }
        };

    public static Dictionary<(QRMaskPattern, QRErrorCorrectionLevel), short> Table =
    new Dictionary<(QRMaskPattern, QRErrorCorrectionLevel), short>
    {
        // Level L
        {(QRMaskPattern.Pattern0, QRErrorCorrectionLevel.L), 0b111011111000100},
        {(QRMaskPattern.Pattern1, QRErrorCorrectionLevel.L), 0b111001011110011},
        {(QRMaskPattern.Pattern2, QRErrorCorrectionLevel.L), 0b111110110101010},
        {(QRMaskPattern.Pattern3, QRErrorCorrectionLevel.L), 0b111100010011101},
        {(QRMaskPattern.Pattern4, QRErrorCorrectionLevel.L), 0b110011000101111},
        {(QRMaskPattern.Pattern5, QRErrorCorrectionLevel.L), 0b110001100011000},
        {(QRMaskPattern.Pattern6, QRErrorCorrectionLevel.L), 0b110110001000001},
        {(QRMaskPattern.Pattern7, QRErrorCorrectionLevel.L), 0b110100101110110},
        
        // Level M
        {(QRMaskPattern.Pattern0, QRErrorCorrectionLevel.M), 0b101010000010010},
        {(QRMaskPattern.Pattern1, QRErrorCorrectionLevel.M), 0b101000100100101},
        {(QRMaskPattern.Pattern2, QRErrorCorrectionLevel.M), 0b101111001111100},
        {(QRMaskPattern.Pattern3, QRErrorCorrectionLevel.M), 0b101101101001011},
        {(QRMaskPattern.Pattern4, QRErrorCorrectionLevel.M), 0b100010111111001},
        {(QRMaskPattern.Pattern5, QRErrorCorrectionLevel.M), 0b100000011001110},
        {(QRMaskPattern.Pattern6, QRErrorCorrectionLevel.M), 0b100111110010111},
        {(QRMaskPattern.Pattern7, QRErrorCorrectionLevel.M), 0b100101010100000},
        
        // Level Q
        {(QRMaskPattern.Pattern0, QRErrorCorrectionLevel.Q), 0b011010101011111},
        {(QRMaskPattern.Pattern1, QRErrorCorrectionLevel.Q), 0b011000001101000},
        {(QRMaskPattern.Pattern2, QRErrorCorrectionLevel.Q), 0b011111100110001},
        {(QRMaskPattern.Pattern3, QRErrorCorrectionLevel.Q), 0b011101000000110},
        {(QRMaskPattern.Pattern4, QRErrorCorrectionLevel.Q), 0b010010010110100},
        {(QRMaskPattern.Pattern5, QRErrorCorrectionLevel.Q), 0b010000110000011},
        {(QRMaskPattern.Pattern6, QRErrorCorrectionLevel.Q), 0b010111011011010},
        {(QRMaskPattern.Pattern7, QRErrorCorrectionLevel.Q), 0b010101111101101},
        
        // Level H
        {(QRMaskPattern.Pattern0, QRErrorCorrectionLevel.H), 0b001011010001001},
        {(QRMaskPattern.Pattern1, QRErrorCorrectionLevel.H), 0b001001110111110},
        {(QRMaskPattern.Pattern2, QRErrorCorrectionLevel.H), 0b001110011100111},
        {(QRMaskPattern.Pattern3, QRErrorCorrectionLevel.H), 0b001100111010000},
        {(QRMaskPattern.Pattern4, QRErrorCorrectionLevel.H), 0b000011101100010},
        {(QRMaskPattern.Pattern5, QRErrorCorrectionLevel.H), 0b000001001010101},
        {(QRMaskPattern.Pattern6, QRErrorCorrectionLevel.H), 0b000110100001100},
        {(QRMaskPattern.Pattern7, QRErrorCorrectionLevel.H), 0b000100000111011}
    };
}