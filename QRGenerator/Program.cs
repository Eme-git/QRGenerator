
using System.Text;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // для Kanji

        QRDataTest.Run("123HELLOкириллица007", QRErrorCorrectionLevel.H);
        
    }
}