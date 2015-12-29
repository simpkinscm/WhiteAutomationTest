using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using TestStack.White;
using TestStack.White.Configuration;

namespace WhiteFrameworkSandbox
{
    class GlobalVar{
        public static ICoreConfiguration timeouts = CoreAppXmlConfiguration.Instance;
        
        public static string applicationDirectory = TestContext.CurrentContext.TestDirectory;
        public static string exePath = Path.GetFullPath(applicationDirectory + "..\\..\\..\\..\\Flight Application\\Flights Application\\FlightsGUI.exe");
        public static ProcessStartInfo exeProcess = new ProcessStartInfo(exePath);
        public static Application application = Application.AttachOrLaunch(exeProcess);

    }
}
