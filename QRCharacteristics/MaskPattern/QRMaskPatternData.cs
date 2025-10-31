using System.Collections;

public static class QRMaskPatternData
{
    public static Dictionary<QRMaskPattern, (BitArray BitPattern, Func<bool, byte, byte, bool> Mask)> Data { get; private set; } =
        new Dictionary<QRMaskPattern, (BitArray, Func<bool, byte, byte, bool>)>
        {
            {
                QRMaskPattern.Pattern000,
                (
                    new BitArray([false, false, false]),
                    (value, i, j) => value ^ ((j + i) % 2 == 0) // (X + Y) % 2
                )
            },
            {
                QRMaskPattern.Pattern001,
                (
                    new BitArray([false, false, true]),
                    (value, i, j) => value ^ (i % 2 == 0) // Y % 2
                )
            },
            {
                QRMaskPattern.Pattern010,
                (
                    new BitArray([false, true, false]),
                    (value, i, j) => value ^ (j % 3 == 0) // X % 3
                )
            },
            {
                QRMaskPattern.Pattern011,
                (
                    new BitArray([false, true, true]),
                    (value, i, j) => value ^ ((j + i) % 3 == 0) // (X + Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern100,
                (
                    new BitArray([true, false, false]),
                    (value, i, j) => value ^ ((j / 3 + i / 2) % 2 == 0) // (X / 3 + Y / 2) % 2
                )
            },
            {
                QRMaskPattern.Pattern101,
                (
                    new BitArray([true, false, true]),
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) == 0) // (X * Y) % 2 + (X * Y) % 3
                )
            },
            {
                QRMaskPattern.Pattern110,
                (
                    new BitArray([true, true, false]),
                    (value, i, j) => value ^ (((j * i) % 2 + (j * i) % 3) % 2 == 0) // ((X * Y) % 2 + (X * Y) % 3) % 2
                )
            },
            {
                QRMaskPattern.Pattern111,
                (
                    new BitArray([true, true, true]),
                    (value, i, j) => value ^ (((j * i) % 3 + (j + i) % 2) % 2 == 0) // ((X * Y) % 3 + (X + Y) % 2) % 2
                )
            }
        };
}