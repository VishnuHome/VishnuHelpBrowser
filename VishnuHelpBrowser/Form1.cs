namespace VishnuHelpBrowser
{
    /// <summary>
    /// Hauptbildschirm des Webbrowsers.
    /// Lädt die Vishnu online Hilfeseite.
    /// Die Anwendung merkt sich die Position und Größe dieses Bildschirms
    /// und stellt sie beim nächsten Aufruf wieder her.
    /// Ebenso wird mit der letzten Url verfahren.
    /// Das Ganze ist unter c:\Users\USER\AppData\Local\NetEti\VishnuHelpBrowser gespeichert.
    /// </summary>
    /// <remarks>
    /// Autor: Erik Nagel, NetEti
    ///
    /// 24.01.2024 Erik Nagel: erstellt.
    /// </remarks>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Standard Konstruktor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this._webUrlString = "https://neteti.de/Vishnu.Doc";
        }

        private string _webUrlString;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetEti.CustomControls.Properties.Settings.Default.WebUrlString = _webUrlString;
            if (WindowState == FormWindowState.Maximized)
            {
                NetEti.CustomControls.Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
                NetEti.CustomControls.Properties.Settings.Default.WindowSize = RestoreBounds.Size;
                NetEti.CustomControls.Properties.Settings.Default.WindowMaximized = true;
                NetEti.CustomControls.Properties.Settings.Default.WindowMinimized = false;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                NetEti.CustomControls.Properties.Settings.Default.WindowLocation = Location;
                NetEti.CustomControls.Properties.Settings.Default.WindowSize = Size;
                NetEti.CustomControls.Properties.Settings.Default.WindowMaximized = false;
                NetEti.CustomControls.Properties.Settings.Default.WindowMinimized = false;
            }
            else
            {
                NetEti.CustomControls.Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
                NetEti.CustomControls.Properties.Settings.Default.WindowSize = RestoreBounds.Size;
                NetEti.CustomControls.Properties.Settings.Default.WindowMaximized = false;
                NetEti.CustomControls.Properties.Settings.Default.WindowMinimized = true;
            }
            NetEti.CustomControls.Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (NetEti.CustomControls.Properties.Settings.Default.WindowMaximized)
            {
                Location = NetEti.CustomControls.Properties.Settings.Default.WindowLocation;
                WindowState = FormWindowState.Maximized;
                Size = NetEti.CustomControls.Properties.Settings.Default.WindowSize;
            }
            else if (NetEti.CustomControls.Properties.Settings.Default.WindowMinimized)
            {
                Location = NetEti.CustomControls.Properties.Settings.Default.WindowLocation;
                WindowState = FormWindowState.Minimized;
                Size = NetEti.CustomControls.Properties.Settings.Default.WindowSize;
            }
            else
            {
                Location = NetEti.CustomControls.Properties.Settings.Default.WindowLocation;
                Size = NetEti.CustomControls.Properties.Settings.Default.WindowSize;
            }
            _webUrlString = NetEti.CustomControls.Properties.Settings.Default.WebUrlString;

            // Setzen der URL, die das WebView2-Steuerelement laden soll
            this.webView21.Source = new Uri(_webUrlString);
        }
    }
}
