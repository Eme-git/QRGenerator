using System.Collections;

public static class QRMaskPatternData
{
    public static List<QRMaskPattern> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRMaskPattern)).Cast<QRMaskPattern>().ToList();

    public static Dictionary<QRMaskPattern, (List<bool> BitPattern, Func<bool, byte, byte, bool> Mask)> Data { get; private set; } =
        new Dictionary<QRMaskPattern, (List<bool>, Func<bool, byte, byte, bool>)>
        {
            {
                QRMaskPattern.Pattern000,
                (
                    [false, false, false],
                    (value, i, j) => value ^ ((j + i) % 2 == 0) // (X + Y) % 2
                )
            },
            {
                QRMaskPattern.Pattern001,
                (
                    [false, false, true],
                    (value, i, j) => value ^ (i % 2 == 0) // Y % 2
                )
            },
            {
                QRMaskPattern.Pattern010,
                (
                    [false, true, false],
                    (value, i, j) => value ^ (j % 3 == 0) // X % 3
                )
            },
            {
                QRMaskPattern.Pattern011,
                (
                    [false, true, true],
                    (value, i, j) => value ^ ((j + i) % 3 == 0) // (X + Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern100,
                (
                    [true, false, false],
                    (value, i, j) => value ^ ((j / 3 + i / 2) % 2 == 0) // (X / 3 + Y / 2) % 2
                )
            },
            {
                QRMaskPattern.Pattern101,
                (
                    [true, false, true],
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) == 0) // (X * Y) % 2 + (X * Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern110,
                (
                    [true, true, false],
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) % 2 == 0) // ((X * Y) % 2 + (X * Y) % 3) % 2
                )
            },
            {
                QRMaskPattern.Pattern111,
                (
                    [true, true, true],
                    (value, i, j) => value ^ (((j * i) % 3 + (j + i) % 2) % 2 == 0) // ((X * Y) % 3 + (X + Y) % 2) % 2
                )
            }
        };
}