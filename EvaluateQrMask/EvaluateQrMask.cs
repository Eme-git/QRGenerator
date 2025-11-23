using System.Drawing;
public static class EvaluateQr
{

    public static int EvaluateQrMask(Bitmap image)
    {
        return
            EvaluateQrMaskRule1(image) +
            EvaluateQrMaskRule2(image);
    }

    public static int EvaluateQrMaskRule1(Bitmap image)
    {
        int totalPoints = 0;

        for (int i = 0; i < image.Width; ++i)
        {
            for (int j = 0, pos = 0; j < image.Height; ++j)
            {
                if (image.GetPixel(i, j) != image.GetPixel(i, pos))
                {
                    if (j - pos >= 5)
                        totalPoints += j - pos - 2;

                    pos = j;
                }
            }
        }

        for (int j = 0; j < image.Height; ++j)
        {
            for (int i = 0, pos = 0; i < image.Width; ++i)
            {
                if (image.GetPixel(i, j) != image.GetPixel(pos, j))
                {
                    if (i - pos >= 5)
                        totalPoints += i - pos - 2;

                    pos = i;
                }
            }
        }

        return totalPoints;
    }

    public static int EvaluateQrMaskRule2(Bitmap image)
    {
        int totalPoints = 0;

        for (int i = 0; i < image.Width - 1; ++i)
        {
            for (int j = 0; j < image.Height - 1; ++j)
            {
                if (image.GetPixel(i, j) == image.GetPixel(i + 1, j) &&
                    image.GetPixel(i, j) == image.GetPixel(i, j + 1) &&
                    image.GetPixel(i, j) == image.GetPixel(i + 1, j + 1))
                {
                    totalPoints += 3;
                }
            }
        }

        return totalPoints;
    }

    public static int EvaluateQrMaskRule3(Bitmap image)
    {
        int totalPoints = 0;

        List<Color> pattern =
            [
            Color.Black,
            Color.White,
            Color.Black,
            Color.Black,
            Color.Black,
            Color.White,
            Color.Black,
            Color.White,
            Color.White,
            Color.White,
            Color.White
            ];

        for (int i = 0; i < image.Width; ++i)
            for (int j = 0; j < image.Height - 11; ++j)
            {
                bool fl1 = true, fl2 = false;
                for (int k = 0; k < pattern.Count && (fl1 || fl2); ++k)
                {
                    if (image.GetPixel(i, j + k) != pattern[k])
                        fl1 = false;

                    if (image.GetPixel(i, j + k) != pattern[pattern.Count - k - 1])
                        fl2 = false;
                }

                if (fl1)
                    totalPoints += 40;

                if (fl2)
                    totalPoints += 40;
            }

        for (int j = 0; j < image.Height; ++j)
            for (int i = 0; i < image.Width - 11; ++i)
            {
                bool fl1 = true, fl2 = false;
                for (int k = 0; k < pattern.Count && (fl1 || fl2); ++k)
                {
                    if (image.GetPixel(i + k, j) != pattern[k])
                        fl1 = false;

                    if (image.GetPixel(i + k, j) != pattern[pattern.Count - k - 1])
                        fl2 = false;
                }

                if (fl1)
                    totalPoints += 40;

                if (fl2)
                    totalPoints += 40;
            }

        return totalPoints;
    }
}

