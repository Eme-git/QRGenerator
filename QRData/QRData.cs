using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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

            if (dataList[versionAverage].Count <= ((QRVersion)versionAverage).BitLimit(level))
                versionRight = versionAverage;
            else
                versionLeft = versionAverage;
        }
        if (versionRight == dataList.Count + 1)
        {
            System.Diagnostics.Debug.WriteLine("=====NotFound(to many data)=============");
            return null;
        }
        
        return Padding(new QRData(dataList[versionRight], (QRVersion)versionRight, level));
    }

    private static QRData Padding(QRData data)
    {
        System.Diagnostics.Debug.WriteLine("=====Found==============================");
        System.Diagnostics.Debug.WriteLine($"\tUseful data: {data.Data.Count}");

        // Добавление терминатора
        int terminator = Math.Min(4, data.Version.BitLimit(data.ErrorCorrectionLevel) - data.Data.Count);
        data.Data.AddRange(Enumerable.Repeat(false, terminator));
        System.Diagnostics.Debug.WriteLine(
            $"\tAdded terminator: {terminator}");

        // Паддинг до кратности 8 бит (нулями)
        int padding = (8 - data.Data.Count % 8) % 8;
        System.Diagnostics.Debug.WriteLine(
            $"\tAdded padding: {padding}");
        data.Data.AddRange(Enumerable.Repeat(false, padding));

        // Заполнение буферными данными
        int filling = (data.Version.BitLimit(data.ErrorCorrectionLevel) - data.Data.Count) / 8;
        System.Diagnostics.Debug.WriteLine(
            $"\tAdded filling: {filling * 8}");
        for (int index = 0; filling-- > 0; index = 1 - index)
        {
            data.Data.AddRange(Filling[index]);
        }

        System.Diagnostics.Debug.WriteLine($"Data: {data.Data.Count}({data.Version.BitLimit(data.ErrorCorrectionLevel)})");
        System.Diagnostics.Debug.WriteLine($"Version: {data.Version}");
        System.Diagnostics.Debug.WriteLine($"Error Correction Level: {data.ErrorCorrectionLevel}");
        System.Diagnostics.Debug.WriteLine("========================================");
        return data;
    }

    public static List<byte> BlockedData(QRData data)
    {
        List<byte> bytes = ConvertBoolListToByteList(data.Data);

        List<List<byte>> blocks = new List<List<byte>>();
        List<List<byte>> correctionBytes = new List<List<byte>>();

        List<byte> polynomial 
            = QRErrorCorrectionLevelExtensions.GeneratingPolynomial(data.Version.CorrectionByte(data.ErrorCorrectionLevel));

        int blockCount = data.Version.BlockCount(data.ErrorCorrectionLevel);
        int countDiv = bytes.Count / blockCount;
        int countMod = bytes.Count % blockCount;

        for (int index = 0; blockCount != 0; index += countDiv, blockCount--)
        {
            if (blockCount == countMod)
                countDiv++;

            blocks.Add(bytes.GetRange(index, countDiv));
            correctionBytes.Add(CreateCorrectionBytes(blocks.Last(), polynomial));
        }

        List<byte> finalData = [.. InterleaveDataBytes(blocks), .. InterleaveDataBytes(correctionBytes)];

        return finalData;
    }

    private static List<byte> InterleaveDataBytes(List<List<byte>> dataBlocks)
    {
        var interleavedData = new List<byte>();

        int maxDataBlockSize = dataBlocks.Max(b => b.Count);

        for (int i = 0; i < maxDataBlockSize; i++)
        {
            foreach (var block in dataBlocks)
            {
                if (i < block.Count)
                {
                    interleavedData.Add(block[i]);
                }
            }
        }
        return interleavedData;
    }

    public static List<byte> CreateCorrectionBytes(List<byte> bytes, List<byte> polynomial) {
        List<byte> remainder = [..bytes, .. Enumerable.Repeat((byte)0, Math.Max(0, polynomial.Count - bytes.Count))]; 
        

        for (int index = 0; index < bytes.Count; ++index) 
        { 
            int a = remainder[0];
            remainder.RemoveAt(0);
            remainder.Add(0);
            if (a == 0) continue; 
            int b = QRVersionExtensions.InverseGaloisField(a); 
            for (int i = 0; i < polynomial.Count; ++i) 
            { 
                int B = polynomial[i] + b; 
                B %= 255;
                remainder[i] ^= QRVersionExtensions.GaloisField(B); 
            } 
        } 
        return remainder; 
    }

    public static List<byte> ConvertBoolListToByteList(List<bool> bools)
    {
        List<byte> bytes = new List<byte>();

        for (int i = 0; i < bools.Count; i += 8)
        {
            byte currentByte = 0;
            for (int j = 0; j < 8; j++)
            {
                int boolIndex = i + j;
                if (boolIndex < bools.Count && bools[boolIndex])
                {
                    currentByte |= (byte)(1 << (7 - j));
                }
            }
            bytes.Add(currentByte);
        }

        return bytes;
    }

}
