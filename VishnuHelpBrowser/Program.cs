using NetEti.ApplicationEnvironment;

namespace NetEti.CustomControls
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Hinweis: die "args" werden hier nicht direkt eingelesen, sondern in "CommandLineAccess" ausgewertet.
        /// "WebUrl": eine Webadresse für die darzustellenden Hilfeseiten oder null.
        /// </param>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CommandLineAccess commandLineAccess = new();
            string? webUrlString = commandLineAccess.GetStringValue("HelpUrl", null);

            Application.Run(new VishnuHelpBrowser(webUrlString));
        }
    }
}