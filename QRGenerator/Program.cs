
using System.Text;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // для Kanji
        
        QRGenerator.Generate(new QRData("я написал генератор QR кодов!!", QRErrorCorrectionLevel.H));
    }
}