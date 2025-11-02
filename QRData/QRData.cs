using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

public class QRData
{
    public List<bool> Data { get; private set; }
    public QRVersion Version { get; private set; }
    public QRErrorCorrectionLevel ErrorCorrectionLevel { get; private set; }

    private static bool[][] Filling =
    [
        [ true, true, true, false, true, true, false, false ],
        [ false, false, false, true, false, false, false, true ]
    ];

    public QRData(List<bool> data, QRVersion version, QRErrorCorrectionLevel errorCorrectionLevel)
    {
        Data = data;
        ErrorCorrectionLevel = errorCorrectionLevel;
        Version = version;
    }

    public static QRData? Parse(string data, QRErrorCorrectionLevel level)
    {
        List<List<bool>> dataList = [.. Enumerable.Repeat(new List<bool>(), QRVersionData.AllValues.Count)];
        int versionLeft = 0, versionRight = dataList.Count + 1;
        while (versionLeft + 1 < versionRight)
        {
            int versionAverage = (versionLeft + versionRight) / 2;

            if (dataList[versionAverage].Count == 0)
            {
                dataList[versionAverage] = ((QRVersion)versionAverage).Parse(data);
            }

            if (dataList[versionAverage].Count <= ((QRVersion)versionAverage).getBitLimit(level))
                versionRight = versionAverage;
            else
                versionLeft = versionAverage;
        }
        if (versionRight == dataList.Count + 1)
        {
            return null;
        }


        for (int index = 0; dataList[versionRight].Count < ((QRVersion)versionRight).getBitLimit(level); index = 1 - index)
        {
            dataList[versionRight].AddRange(Filling[index]);
        }

        System.Diagnostics.Debug.WriteLine("-----Found------------------------------");
        System.Diagnostics.Debug.WriteLine($"Data: {dataList[versionRight].Count}({((QRVersion)versionRight).getBitLimit(level)})");
        System.Diagnostics.Debug.WriteLine("Version: " + (QRVersion)versionRight);
        System.Diagnostics.Debug.WriteLine("Error Correction Level: " + level);
        System.Diagnostics.Debug.WriteLine("----------------------------------------");

        return new QRData(dataList[versionRight], (QRVersion)versionRight, level);
    }
}

