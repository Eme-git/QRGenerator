public class QRVersionData
{
    public static List<QRVersion> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRVersion)).Cast<QRVersion>().ToList();

    public static Dictionary<(QRVersion, QRErrorCorrectionLevel), (int BitLimit, int BlockCount, int CorrectionByte)> Data { get; private set; } =
    new Dictionary<(QRVersion, QRErrorCorrectionLevel), (int, int, int)>
    {
        {(QRVersion.V1,  QRErrorCorrectionLevel.L), (152,   1,  7)},
        {(QRVersion.V1,  QRErrorCorrectionLevel.M), (128,   1,  10)},
        {(QRVersion.V1,  QRErrorCorrectionLevel.Q), (104,   1,  13)},
        {(QRVersion.V1,  QRErrorCorrectionLevel.H), (72,    1,  17)},
                         
        {(QRVersion.V2,  QRErrorCorrectionLevel.L), (272,   1,  10)},
        {(QRVersion.V2,  QRErrorCorrectionLevel.M), (224,   1,  16)},
        {(QRVersion.V2,  QRErrorCorrectionLevel.Q), (176,   1,  22)},
        {(QRVersion.V2,  QRErrorCorrectionLevel.H), (128,   1,  28)},
                         
        {(QRVersion.V3,  QRErrorCorrectionLevel.L), (440,   1,  15)},
        {(QRVersion.V3,  QRErrorCorrectionLevel.M), (352,   1,  26)},
        {(QRVersion.V3,  QRErrorCorrectionLevel.Q), (272,   2,  18)},
        {(QRVersion.V3,  QRErrorCorrectionLevel.H), (208,   2,  22)},
                         
        {(QRVersion.V4,  QRErrorCorrectionLevel.L), (640,   1,  20)},
        {(QRVersion.V4,  QRErrorCorrectionLevel.M), (512,   2,  18)},
        {(QRVersion.V4,  QRErrorCorrectionLevel.Q), (384,   2,  26)},
        {(QRVersion.V4,  QRErrorCorrectionLevel.H), (288,   4,  16)},
                         
        {(QRVersion.V5,  QRErrorCorrectionLevel.L), (864,   1,  26)},
        {(QRVersion.V5,  QRErrorCorrectionLevel.M), (688,   2,  24)},
        {(QRVersion.V5,  QRErrorCorrectionLevel.Q), (496,   4,  18)},
        {(QRVersion.V5,  QRErrorCorrectionLevel.H), (368,   4,  22)},
                         
        {(QRVersion.V6,  QRErrorCorrectionLevel.L), (1088,  2,  18)},
        {(QRVersion.V6,  QRErrorCorrectionLevel.M), (864,   4,  16)},
        {(QRVersion.V6,  QRErrorCorrectionLevel.Q), (608,   4,  24)},
        {(QRVersion.V6,  QRErrorCorrectionLevel.H), (480,   4,  28)},
                         
        {(QRVersion.V7,  QRErrorCorrectionLevel.L), (1248,  2,  20)},
        {(QRVersion.V7,  QRErrorCorrectionLevel.M), (992,   4,  18)},
        {(QRVersion.V7,  QRErrorCorrectionLevel.Q), (704,   6,  18)},
        {(QRVersion.V7,  QRErrorCorrectionLevel.H), (528,   5,  26)},
                         
        {(QRVersion.V8,  QRErrorCorrectionLevel.L), (1552,  2,  24)},
        {(QRVersion.V8,  QRErrorCorrectionLevel.M), (1232,  4,  22)},
        {(QRVersion.V8,  QRErrorCorrectionLevel.Q), (880,   6,  22)},
        {(QRVersion.V8,  QRErrorCorrectionLevel.H), (688,   6,  26)},
                         
        {(QRVersion.V9,  QRErrorCorrectionLevel.L), (1856,  2,  30)},
        {(QRVersion.V9,  QRErrorCorrectionLevel.M), (1456,  5,  22)},
        {(QRVersion.V9,  QRErrorCorrectionLevel.Q), (1056,  8,  20)},
        {(QRVersion.V9,  QRErrorCorrectionLevel.H), (800,   8,  24)},

        {(QRVersion.V10, QRErrorCorrectionLevel.L), (2192,  4,  18)},
        {(QRVersion.V10, QRErrorCorrectionLevel.M), (1728,  5,  26)},
        {(QRVersion.V10, QRErrorCorrectionLevel.Q), (1232,  8,  24)},
        {(QRVersion.V10, QRErrorCorrectionLevel.H), (976,   8,  28)},

        {(QRVersion.V11, QRErrorCorrectionLevel.L), (2592,  4,  20)},
        {(QRVersion.V11, QRErrorCorrectionLevel.M), (2032,  5,  30)},
        {(QRVersion.V11, QRErrorCorrectionLevel.Q), (1440,  8,  28)},
        {(QRVersion.V11, QRErrorCorrectionLevel.H), (1120,  11, 24)},

        {(QRVersion.V12, QRErrorCorrectionLevel.L), (2960,  4,  24)},
        {(QRVersion.V12, QRErrorCorrectionLevel.M), (2320,  8,  22)},
        {(QRVersion.V12, QRErrorCorrectionLevel.Q), (1648,  10, 26)},
        {(QRVersion.V12, QRErrorCorrectionLevel.H), (1264,  11, 28)},

        {(QRVersion.V13, QRErrorCorrectionLevel.L), (3424,  4,  26)},
        {(QRVersion.V13, QRErrorCorrectionLevel.M), (2672,  9,  22)},
        {(QRVersion.V13, QRErrorCorrectionLevel.Q), (1952,  12, 24)},
        {(QRVersion.V13, QRErrorCorrectionLevel.H), (1440,  16, 22)},

        {(QRVersion.V14, QRErrorCorrectionLevel.L), (3688,  4,  30)},
        {(QRVersion.V14, QRErrorCorrectionLevel.M), (2920,  9,  24)},
        {(QRVersion.V14, QRErrorCorrectionLevel.Q), (2088,  16, 20)},
        {(QRVersion.V14, QRErrorCorrectionLevel.H), (1576,  16, 24)},

        {(QRVersion.V15, QRErrorCorrectionLevel.L), (4184,  6,  22)},
        {(QRVersion.V15, QRErrorCorrectionLevel.M), (3320,  10, 24)},
        {(QRVersion.V15, QRErrorCorrectionLevel.Q), (2360,  12, 30)},
        {(QRVersion.V15, QRErrorCorrectionLevel.H), (1784,  18, 24)},

        {(QRVersion.V16, QRErrorCorrectionLevel.L), (4712,  6,  24)},
        {(QRVersion.V16, QRErrorCorrectionLevel.M), (3624,  10, 28)},
        {(QRVersion.V16, QRErrorCorrectionLevel.Q), (2600,  17, 24)},
        {(QRVersion.V16, QRErrorCorrectionLevel.H), (2024,  16, 30)},

        {(QRVersion.V17, QRErrorCorrectionLevel.L), (5176,  6,  28)},
        {(QRVersion.V17, QRErrorCorrectionLevel.M), (4056,  11, 28)},
        {(QRVersion.V17, QRErrorCorrectionLevel.Q), (2936,  16, 28)},
        {(QRVersion.V17, QRErrorCorrectionLevel.H), (2264,  19, 28)},

        {(QRVersion.V18, QRErrorCorrectionLevel.L), (5768,  6,  30)},
        {(QRVersion.V18, QRErrorCorrectionLevel.M), (4504,  13, 26)},
        {(QRVersion.V18, QRErrorCorrectionLevel.Q), (3176,  18, 28)},
        {(QRVersion.V18, QRErrorCorrectionLevel.H), (2504,  21, 28)},

        {(QRVersion.V19, QRErrorCorrectionLevel.L), (6360,  7,  28)},
        {(QRVersion.V19, QRErrorCorrectionLevel.M), (5016,  14, 26)},
        {(QRVersion.V19, QRErrorCorrectionLevel.Q), (3560,  21, 26)},
        {(QRVersion.V19, QRErrorCorrectionLevel.H), (2728,  25, 26)},

        {(QRVersion.V20, QRErrorCorrectionLevel.L), (6888,  8,  28)},
        {(QRVersion.V20, QRErrorCorrectionLevel.M), (5352,  16, 26)},
        {(QRVersion.V20, QRErrorCorrectionLevel.Q), (3880,  20, 30)},
        {(QRVersion.V20, QRErrorCorrectionLevel.H), (3080,  25, 28)},

        {(QRVersion.V21, QRErrorCorrectionLevel.L), (7456,  8,  28)},
        {(QRVersion.V21, QRErrorCorrectionLevel.M), (5712,  17, 26)},
        {(QRVersion.V21, QRErrorCorrectionLevel.Q), (4096,  23, 28)},
        {(QRVersion.V21, QRErrorCorrectionLevel.H), (3248,  25, 30)},

        {(QRVersion.V22, QRErrorCorrectionLevel.L), (8048,  9,  28)},
        {(QRVersion.V22, QRErrorCorrectionLevel.M), (6256,  17, 28)},
        {(QRVersion.V22, QRErrorCorrectionLevel.Q), (4544,  23, 30)},
        {(QRVersion.V22, QRErrorCorrectionLevel.H), (3536,  34, 24)},

        {(QRVersion.V23, QRErrorCorrectionLevel.L), (8752,  9,  30)},
        {(QRVersion.V23, QRErrorCorrectionLevel.M), (6880,  18, 28)},
        {(QRVersion.V23, QRErrorCorrectionLevel.Q), (4912,  25, 30)},
        {(QRVersion.V23, QRErrorCorrectionLevel.H), (3712,  30, 30)},

        {(QRVersion.V24, QRErrorCorrectionLevel.L), (9392,  10, 30)},
        {(QRVersion.V24, QRErrorCorrectionLevel.M), (7312,  20, 28)},
        {(QRVersion.V24, QRErrorCorrectionLevel.Q), (5312,  27, 30)},
        {(QRVersion.V24, QRErrorCorrectionLevel.H), (4112,  32, 30)},

        {(QRVersion.V25, QRErrorCorrectionLevel.L), (10208, 12, 26)},
        {(QRVersion.V25, QRErrorCorrectionLevel.M), (8000,  21, 28)},
        {(QRVersion.V25, QRErrorCorrectionLevel.Q), (5744,  29, 30)},
        {(QRVersion.V25, QRErrorCorrectionLevel.H), (4304,  35, 30)},

        {(QRVersion.V26, QRErrorCorrectionLevel.L), (10960, 12, 28)},
        {(QRVersion.V26, QRErrorCorrectionLevel.M), (8496,  23, 28)},
        {(QRVersion.V26, QRErrorCorrectionLevel.Q), (6032,  34, 28)},
        {(QRVersion.V26, QRErrorCorrectionLevel.H), (4768,  37, 30)},

        {(QRVersion.V27, QRErrorCorrectionLevel.L), (11744, 12, 30)},
        {(QRVersion.V27, QRErrorCorrectionLevel.M), (9024,  25, 28)},
        {(QRVersion.V27, QRErrorCorrectionLevel.Q), (6464,  34, 30)},
        {(QRVersion.V27, QRErrorCorrectionLevel.H), (5024,  40, 30)},

        {(QRVersion.V28, QRErrorCorrectionLevel.L), (12248, 13, 30)},
        {(QRVersion.V28, QRErrorCorrectionLevel.M), (9544,  26, 28)},
        {(QRVersion.V28, QRErrorCorrectionLevel.Q), (6968,  35, 30)},
        {(QRVersion.V28, QRErrorCorrectionLevel.H), (5288,  42, 30)},

        {(QRVersion.V29, QRErrorCorrectionLevel.L), (13048, 14, 30)},
        {(QRVersion.V29, QRErrorCorrectionLevel.M), (10136, 28, 28)},
        {(QRVersion.V29, QRErrorCorrectionLevel.Q), (7288,  38, 30)},
        {(QRVersion.V29, QRErrorCorrectionLevel.H), (5608,  45, 30)},

        {(QRVersion.V30, QRErrorCorrectionLevel.L), (13880, 15, 30)},
        {(QRVersion.V30, QRErrorCorrectionLevel.M), (10984, 29, 28)},
        {(QRVersion.V30, QRErrorCorrectionLevel.Q), (7880,  40, 30)},
        {(QRVersion.V30, QRErrorCorrectionLevel.H), (5960,  48, 30)},

        {(QRVersion.V31, QRErrorCorrectionLevel.L), (14744, 16, 30)},
        {(QRVersion.V31, QRErrorCorrectionLevel.M), (11640, 31, 28)},
        {(QRVersion.V31, QRErrorCorrectionLevel.Q), (8264,  43, 30)},
        {(QRVersion.V31, QRErrorCorrectionLevel.H), (6344,  51, 30)},

        {(QRVersion.V32, QRErrorCorrectionLevel.L), (15640, 17, 30)},
        {(QRVersion.V32, QRErrorCorrectionLevel.M), (12328, 33, 28)},
        {(QRVersion.V32, QRErrorCorrectionLevel.Q), (8920,  45, 30)},
        {(QRVersion.V32, QRErrorCorrectionLevel.H), (6760,  54, 30)},

        {(QRVersion.V33, QRErrorCorrectionLevel.L), (16568, 18, 30)},
        {(QRVersion.V33, QRErrorCorrectionLevel.M), (13048, 35, 28)},
        {(QRVersion.V33, QRErrorCorrectionLevel.Q), (9368,  48, 30)},
        {(QRVersion.V33, QRErrorCorrectionLevel.H), (7208,  57, 30)},

        {(QRVersion.V34, QRErrorCorrectionLevel.L), (17528, 19, 30)},
        {(QRVersion.V34, QRErrorCorrectionLevel.M), (13800, 37, 28)},
        {(QRVersion.V34, QRErrorCorrectionLevel.Q), (9848,  51, 30)},
        {(QRVersion.V34, QRErrorCorrectionLevel.H), (7688,  60, 30)},

        {(QRVersion.V35, QRErrorCorrectionLevel.L), (18448, 19, 30)},
        {(QRVersion.V35, QRErrorCorrectionLevel.M), (14496, 38, 28)},
        {(QRVersion.V35, QRErrorCorrectionLevel.Q), (10288, 53, 30)},
        {(QRVersion.V35, QRErrorCorrectionLevel.H), (7888,  63, 30)},

        {(QRVersion.V36, QRErrorCorrectionLevel.L), (19472, 20, 30)},
        {(QRVersion.V36, QRErrorCorrectionLevel.M), (15312, 40, 28)},
        {(QRVersion.V36, QRErrorCorrectionLevel.Q), (10832, 56, 30)},
        {(QRVersion.V36, QRErrorCorrectionLevel.H), (8432,  66, 30)},

        {(QRVersion.V37, QRErrorCorrectionLevel.L), (20528, 21, 30)},
        {(QRVersion.V37, QRErrorCorrectionLevel.M), (15936, 43, 28)},
        {(QRVersion.V37, QRErrorCorrectionLevel.Q), (11408, 59, 30)},
        {(QRVersion.V37, QRErrorCorrectionLevel.H), (8768,  70, 30)},

        {(QRVersion.V38, QRErrorCorrectionLevel.L), (21616, 22, 30)},
        {(QRVersion.V38, QRErrorCorrectionLevel.M), (16816, 45, 28)},
        {(QRVersion.V38, QRErrorCorrectionLevel.Q), (12016, 62, 30)},
        {(QRVersion.V38, QRErrorCorrectionLevel.H), (9136,  74, 30)},

        {(QRVersion.V39, QRErrorCorrectionLevel.L), (22496, 24, 30)},
        {(QRVersion.V39, QRErrorCorrectionLevel.M), (17728, 47, 28)},
        {(QRVersion.V39, QRErrorCorrectionLevel.Q), (12656, 65, 30)},
        {(QRVersion.V39, QRErrorCorrectionLevel.H), (9776,  77, 30)},

        {(QRVersion.V40, QRErrorCorrectionLevel.L), (23648, 25, 30)},
        {(QRVersion.V40, QRErrorCorrectionLevel.M), (18672, 49, 28)},
        {(QRVersion.V40, QRErrorCorrectionLevel.Q), (13328, 68, 30)},
        {(QRVersion.V40, QRErrorCorrectionLevel.H), (10208, 81, 30)},
    };

}
