public class QRVersionData
{
    public static List<QRVersion> AllValues { get; private set; }
        = Enum.GetValues(typeof(QRVersion)).Cast<QRVersion>().ToList();

    public static byte[] GaloisField = 
        [
            1,   2,   4,   8,   16,  32,  64,  128, 29,  58,  116, 232, 205, 135, 19,  38,
            76,  152, 45,  90,  180, 117, 234, 201, 143, 3,   6,   12,  24,  48,  96,  192,
            157, 39,  78,  156, 37,  74,  148, 53,  106, 212, 181, 119, 238, 193, 159, 35,
            70,  140, 5,   10,  20,  40,  80,  160, 93,  186, 105, 210, 185, 111, 222, 161,
            95,  190, 97,  194, 153, 47,  94,  188, 101, 202, 137, 15,  30,  60,  120, 240,
            253, 231, 211, 187, 107, 214, 177, 127, 254, 225, 223, 163, 91,  182, 113, 226,
            217, 175, 67,  134, 17,  34,  68,  136, 13,  26,  52,  104, 208, 189, 103, 206,
            129, 31,  62,  124, 248, 237, 199, 147, 59,  118, 236, 197, 151, 51,  102, 204,
            133, 23,  46,  92,  184, 109, 218, 169, 79,  158, 33,  66,  132, 21,  42,  84,
            168, 77,  154, 41,  82,  164, 85,  170, 73,  146, 57,  114, 228, 213, 183, 115,
            230, 209, 191, 99,  198, 145, 63,  126, 252, 229, 215, 179, 123, 246, 241, 255,
            227, 219, 171, 75,  150, 49,  98,  196, 149, 55,  110, 220, 165, 87,  174, 65,
            130, 25,  50,  100, 200, 141, 7,   14,  28,  56,  112, 224, 221, 167, 83,  166,
            81,  162, 89,  178, 121, 242, 249, 239, 195, 155, 43,  86,  172, 69,  138, 9,
            18,  36,  72,  144, 61,  122, 244, 245, 247, 243, 251, 235, 203, 139, 11,  22,
            44,  88,  176, 125, 250, 233, 207, 131, 27,  54,  108, 216, 173, 71,  142, 1
        ];

    public static byte[] InverseGaloisField =
        [
            0,   0,   1,   25,  2,   50,  26,  198, 3,   223, 51,  238, 27,  104, 199, 75,
            4,   100, 224, 14,  52,  141, 239, 129, 28,  193, 105, 248, 200, 8,   76,  113,
            5,   138, 101, 47,  225, 6,   15,  33,  53,  147, 142, 218, 240, 18,  130, 69,
            29,  181, 194, 125, 106, 39,  249, 185, 201, 154, 9,   120, 77,  228, 114, 166,
            6,   191, 139, 98,  102, 221, 48,  253, 226, 152, 37,  179, 16,  145, 34,  136,
            54,  208, 148, 206, 143, 150, 219, 189, 241, 210, 19,  92,  131, 56,  70,  64,
            30,  66,  182, 163, 195, 72,  126, 110, 107, 58,  40,  84,  250, 133, 186, 61,
            202,  94, 155, 159, 10,  21,  121, 43,  78,  212, 229, 172, 115, 243, 167, 87,
            7,   112, 192, 247, 140, 128, 99,  13,  103, 74,  222, 237, 49,  197, 254, 24,
            227, 165, 153, 119, 38,  184, 180, 124, 17,  68,  146, 217, 35,  32,  137, 46,
            55,  63,  209, 91,  149, 188, 207, 205, 144, 135, 151, 178, 220, 252, 190, 97,
            242,  86, 211, 171, 20,  42,  93,  158, 132, 60,  57,  83,  71,  109, 65,  162,
            31,  45,  67,  216, 183, 123, 164, 118, 196, 23,  73,  236, 127, 12,  111, 246,
            108, 161, 59,  82,  41,  157, 85,  170, 251, 96,  134, 177, 187, 204, 62,  90,
            203,  89, 95,  176, 156, 169, 160, 81,  11,  245, 22,  235, 122, 117, 44,  215,
            79,  174, 213, 233, 230, 231, 173, 232, 116, 214, 244, 234, 168, 80,  88,  175
        ];

    public static Dictionary<QRVersion, (byte[] alignmentPatternPositions, byte[] versionCodes)> Data2 =
        new Dictionary<QRVersion, (byte[], byte[])>
    {
        {QRVersion.V1,  ([],                             [])},
        {QRVersion.V2,  ([18],                           [])},
        {QRVersion.V3,  ([22],                           [])},
        {QRVersion.V4,  ([26],                           [])},
        {QRVersion.V5,  ([30],                           [])},
        {QRVersion.V6,  ([34],                           [])},
        {QRVersion.V7,  ([6, 22, 38],                    [0b000010, 0b011110, 0b100110])},
        {QRVersion.V8,  ([6, 24, 42],                    [0b010001, 0b011100, 0b111000])},
        {QRVersion.V9,  ([6, 26, 46],                    [0b110111, 0b011000, 0b000100])},
        {QRVersion.V10, ([6, 28, 50],                    [0b101001, 0b111110, 0b000000])},
        {QRVersion.V11, ([6, 30, 54],                    [0b001111, 0b111010, 0b111100])},
        {QRVersion.V12, ([6, 32, 58],                    [0b001101, 0b100100, 0b011010])},
        {QRVersion.V13, ([6, 34, 62],                    [0b101011, 0b100000, 0b100110])},
        {QRVersion.V14, ([6, 26, 46, 66],                [0b110101, 0b000110, 0b100010])},
        {QRVersion.V15, ([6, 26, 48, 70],                [0b010011, 0b000010, 0b011110])},
        {QRVersion.V16, ([6, 26, 50, 74],                [0b011100, 0b010001, 0b011100])},
        {QRVersion.V17, ([6, 30, 54, 78],                [0b111010, 0b010101, 0b100000])},
        {QRVersion.V18, ([6, 30, 56, 82],                [0b100100, 0b110011, 0b100100])},
        {QRVersion.V19, ([6, 30, 58, 86],                [0b000010, 0b110111, 0b011000])},
        {QRVersion.V20, ([6, 34, 62, 90],                [0b000000, 0b101001, 0b111110])},
        {QRVersion.V21, ([6, 28, 50, 72, 94],            [0b100110, 0b101101, 0b000010])},
        {QRVersion.V22, ([6, 26, 50, 74, 98],            [0b111000, 0b001011, 0b000110])},
        {QRVersion.V23, ([6, 30, 54, 78, 102],           [0b011110, 0b001111, 0b111010])},
        {QRVersion.V24, ([6, 28, 54, 80, 106],           [0b001101, 0b001101, 0b100100])},
        {QRVersion.V25, ([6, 32, 58, 84, 110],           [0b101011, 0b001001, 0b011000])},
        {QRVersion.V26, ([6, 30, 58, 86, 114],           [0b110101, 0b101111, 0b011100])},
        {QRVersion.V27, ([6, 34, 62, 90, 118],           [0b010011, 0b101011, 0b100000])},
        {QRVersion.V28, ([6, 26, 50, 74, 98, 122],       [0b010001, 0b110101, 0b000110])},
        {QRVersion.V29, ([6, 30, 54, 78, 102, 126],      [0b110111, 0b110001, 0b111010])},
        {QRVersion.V30, ([6, 26, 52, 78, 104, 130],      [0b101001, 0b010111, 0b111110])},
        {QRVersion.V31, ([6, 30, 56, 82, 108, 134],      [0b001111, 0b010011, 0b000010])},
        {QRVersion.V32, ([6, 34, 60, 86, 112, 138],      [0b101000, 0b011000, 0b101101])},
        {QRVersion.V33, ([6, 30, 58, 86, 114, 142],      [0b001110, 0b011100, 0b010001])},
        {QRVersion.V34, ([6, 34, 62, 90, 118, 146],      [0b010000, 0b111010, 0b010101])},
        {QRVersion.V35, ([6, 30, 54, 78, 102, 126, 150], [0b110110, 0b111110, 0b101001])},
        {QRVersion.V36, ([6, 24, 50, 76, 102, 128, 154], [0b110100, 0b100000, 0b001111])},
        {QRVersion.V37, ([6, 28, 54, 80, 106, 132, 158], [0b010010, 0b100100, 0b110011])},
        {QRVersion.V38, ([6, 32, 58, 84, 110, 136, 162], [0b001100, 0b000010, 0b110111])},
        {QRVersion.V39, ([6, 26, 54, 82, 110, 138, 166], [0b101010, 0b000110, 0b001011])},
        {QRVersion.V40, ([6, 30, 58, 86, 114, 142, 170], [0b111001, 0b000100, 0b010101])}
    };

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