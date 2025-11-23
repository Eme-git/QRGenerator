
using System.Text;

public static class EvaluateQrMask
{

    public static int EvaluateQr(Bitmap image)
    {
        return
            EvaluateQrMaskRule1(image) +
            EvaluateQrMaskRule2(image) +
            EvaluateQrMaskRule3(image) +
            EvaluateQrMaskRule4(image);
    }

    public static int EvaluateQrMaskRule1(Bitmap image)
    {
        int totalPoints = 0;

        for (int i = 0; i < image.Width; ++i)
            for (int j = 0, pos = 0; j < image.Height; ++j)
                if (image.GetPixel(i, j) != image.GetPixel(i, pos))
                {
                    if (j - pos >= 5)
                        totalPoints += j - pos - 2;

                    pos = j;
                }
            
        

        for (int j = 0; j < image.Height; ++j)
            for (int i = 0, pos = 0; i < image.Width; ++i)
                if (image.GetPixel(i, j) != image.GetPixel(pos, j))
                {
                    if (i - pos >= 5)
                        totalPoints += i - pos - 2;

                    pos = i;
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

    public static int PrefixFunction(Bitmap image, int I, int J, string pref)
    {
        StringBuilder s = new StringBuilder(pref);
        s.Append(" ");
        if (I == -1)
            for (int i = 0; i < image.Width; ++i)
                s.Append(image.GetPixel(i, J) == Color.Black ? 1 : 0);
        else
            for (int j = 0; j < image.Height; ++j)
                s.Append(image.GetPixel(I, j) == Color.Black ? 1 : 0);

        int n = s.Length, ans = 0;
        int[] pi = new int[n];

        for (int i = 1; i < n; i++)
        {
            int j = pi[i - 1];

            while (j > 0 && s[i] != s[j])
                j = pi[j - 1];

            if (s[i] == s[j])
                j++;

            pi[i] = j;
            if (j == pref.Length)
                ++ans;
        }

        return ans;
    }

    public static int EvaluateQrMaskRule3(Bitmap image)
    {
        int totalPoints = 0;

        string 
            pattern1 =     "10111010000",
            pattern2 = "00001011101",
            pattern3 = "000010111010000";

        for (int i = 0; i < image.Width; ++i)
            totalPoints += 
                40 * PrefixFunction(image, i, -1, pattern1) + 
                40 * PrefixFunction(image, i, -1, pattern2) + 
                40 * PrefixFunction(image, i, -1, pattern3) + 
                40 * PrefixFunction(image, -1, i, pattern1) + 
                40 * PrefixFunction(image, -1, i, pattern2) + 
                40 * PrefixFunction(image, -1, i, pattern3);

        return totalPoints;
    }

    public static int EvaluateQrMaskRule4(Bitmap image)
    {
        int white = 0, black = 0;

        for (int i = 0; i < image.Width; ++i)
            for (int j = 0; j < image.Height; ++j)
                if (image.GetPixel(i, j) == Color.White)
                    ++white;
                else
                    ++black;

        return Math.Abs((int)Math.Floor((double)white * 100 / black - 50));
    }
}

