
using System.Text;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // для Kanji
        
            QRGenerator.Generate(new QRData(new List<bool>(), QRVersion.V7, QRErrorCorrectionLevel.H));
    }
}