
using System.Text;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // для Kanji
        
        QRGenerator.Generate(new QRData("1234567890QWERTY!!_", QRErrorCorrectionLevel.L));
    }
}