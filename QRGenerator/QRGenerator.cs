using System;
using System.Drawing;

public static class QRGenerator
{
    private static Color[][] SearchPattern = 
        [ 
            [Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black], 
            [Color.Black, Color.White, Color.White, Color.White, Color.White, Color.White, Color.Black],
            [Color.Black, Color.White, Color.Black, Color.Black, Color.Black, Color.White, Color.Black],
            [Color.Black, Color.White, Color.Black, Color.Black, Color.Black, Color.White, Color.Black],
            [Color.Black, Color.White, Color.Black, Color.Black, Color.Black, Color.White, Color.Black],
            [Color.Black, Color.White, Color.White, Color.White, Color.White, Color.White, Color.Black],
            [Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black]
        ];

    private static Color[][] AlignmentPattern =
        [
            [Color.Black, Color.Black, Color.Black, Color.Black, Color.Black],
            [Color.Black, Color.White, Color.White, Color.White, Color.Black],
            [Color.Black, Color.White, Color.Black, Color.White, Color.Black],
            [Color.Black, Color.White, Color.White, Color.White, Color.Black],
            [Color.Black, Color.Black, Color.Black, Color.Black, Color.Black],
        ];

    private static void AddPatterns(Bitmap image, byte[] alignments)
    {
        for (int i = 0; i < SearchPattern.Length; i++)
        {
            for (int j = 0; j < SearchPattern[i].Length; j++)
            {
                image.SetPixel(i, j, SearchPattern[i][j]);
                image.SetPixel(image.Width - SearchPattern.Length + i, j, SearchPattern[i][j]);
                image.SetPixel(i, image.Height - SearchPattern.Length + j, SearchPattern[i][j]);
            }
        }

        foreach (var x in alignments)
        {
            foreach (var y in alignments)
            {
                if (alignments.First() != 6 ||
                    !(x == y && x == alignments.First() ||
                    x == alignments.First() && y == alignments.Last() ||
                    x == alignments.Last() && y == alignments.First()))
                {
                    for (int i = 0; i < AlignmentPattern.Length; i++)
                        for (int j = 0; j < AlignmentPattern[i].Length; j++)
                            image.SetPixel(x - 2 + i, y - 2 + j, AlignmentPattern[i][j]);
                }
            }
        }

        for (int i = 8; i < image.Width - 8; i++) 
        {
            image.SetPixel(6, i, i % 2 == 0 ? Color.Black : Color.White);
            image.SetPixel(i, 6, i % 2 == 0 ? Color.Black : Color.White);
        }

        for (int i = 0; i < 8; ++i)
        {
            image.SetPixel(7, i, Color.White);
            image.SetPixel(image.Width - 8, i, Color.White);
            image.SetPixel(7, image.Height - 8 + i, Color.White);

            image.SetPixel(i, 7, Color.White);
            image.SetPixel(i, image.Width - 8, Color.White);
            image.SetPixel(image.Height - 8 + i, 7, Color.White);
        }
    }

    public static void AddVersionCode(Bitmap image, QRVersion version)
    {
        var code = version.Code();
        for (int i = 0; i < code.Length; ++i)
        {
            for (int ind = 0; ind < 6; ++ind)
            {
                Color col = (code[i] & (1 << (5 - ind))) != 0 ? Color.Black : Color.White;

                image.SetPixel(image.Width - 11 + i, ind, col);
                image.SetPixel(ind, image.Height - 11 + i, col);
            }
        }
    }

    public static void AddMaskCodeAndCorrectionLevel
        (Bitmap image, QRMaskPattern pattern, QRErrorCorrectionLevel level)
    {
        short code = QRMaskPatternExtensions.MaskCodeAndCorrectionLevel(pattern, level);

        int k = 14, i = 0, j = 8;

        for (; k > 7; --k, i = i == 5 ? 7 : i + 1)
        {
            image.SetPixel(i, j, (code & (1 << k)) != 0 ? Color.Black : Color.White);
        }

        for (; k >= 0; --k, j = j == 7 ? 5 : j - 1)
        {
            image.SetPixel(i, j, (code & (1 << k)) != 0 ? Color.Black : Color.White);
        }
        
        k = 14;
        j = image.Height - 1;
        for (; k >= 8; --k, --j)
        {
            image.SetPixel(8, j, (code & (1 << k)) != 0 ? Color.Black : Color.White);
        }
        image.SetPixel(8, j, Color.Black);

        i = image.Width - 8;
        j = 8;
        for (; k >= 0; --k, ++i)
        {
            image.SetPixel(i, j, (code & (1 << k)) != 0 ? Color.Black : Color.White);
        }
    }

    public static void Generate(QRData QRCode)
    {
        var data = QRCode.Data;
        var version = QRCode.Version;
        var level = QRCode.ErrorCorrectionLevel;

        var size = version.Size();

        Bitmap image = new Bitmap(size, size);

        AddPatterns(image, version.AlignmentPatternsPositions());

        AddVersionCode(image, version);

        AddMaskCodeAndCorrectionLevel(image, QRMaskPattern.Pattern0, level);

        image.Save("try1.png");
    }
}

