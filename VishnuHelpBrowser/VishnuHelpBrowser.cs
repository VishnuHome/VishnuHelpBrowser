using Microsoft.Web.WebView2.Core;

namespace NetEti.CustomControls
{
    /// <summary>
    /// Standalone Webbrowser zur Anzeige der Vishnu Onlinehilfe.
    /// Die Anwendung merkt sich die Position und Größe dieses Bildschirms
    /// und stellt sie beim nächsten Aufruf wieder her. Ebenso wird mit der letzten Url verfahren.
    /// Diese letzten Einstellungen werden unter c:\Users\&lt;user&gt;\AppData\Local\NetEti\VishnuHelpBrowser gespeichert.
    /// </summary>
    /// <remarks>
    ///
    /// 24.01.2024 Erik Nagel: erstellt.
    /// </remarks>
    public partial class VishnuHelpBrowser : Form
    {
        /// <summary>
        /// Standard Konstruktor.
        /// </summary>
        public VishnuHelpBrowser()
        {
            InitializeComponent();
            btnBack.Enabled = false;
            btnForward.Enabled = false;
            btnSearch.Enabled = true;
            btnSearch.BackgroundImage = NetEti.CustomControls.Properties.Resources.search;
            this._webUrlString = "https://neteti.de/Vishnu.Doc";
            this._keywordToPages = new();
        }

        private string _webUrlString;
        private Dictionary<string, List<string>> _keywordToPages;

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

            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;

            // Setzen der URL, die das WebView2-Steuerelement laden soll
            this.webView21.Source = new Uri(_webUrlString);
        }

        private void WebView21_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
        }

        private void CoreWebView2_HistoryChanged(object? sender, object e)
        {
            if (webView21.CanGoBack)
            {
                btnBack.BackgroundImage = NetEti.CustomControls.Properties.Resources.back_enabled;
                btnBack.Enabled = true;
            }
            else
            {
                btnBack.BackgroundImage = NetEti.CustomControls.Properties.Resources.back_disabled;
                btnBack.Enabled = false;
            }
            if (webView21.CanGoForward)
            {
                btnForward.BackgroundImage = NetEti.CustomControls.Properties.Resources.forward_enabled;
                btnForward.Enabled = true;
            }
            else
            {
                btnForward.BackgroundImage = NetEti.CustomControls.Properties.Resources.forward_disabled;
                btnForward.Enabled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoBack)
            {
                webView21.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoForward)
            {
                webView21.GoForward();
            }
        }

        async void PerformSearch(string searchText)
        {
            // Führt die Volltextsuche im WebView2-Kontext durch.
            this._keywordToPages.Clear();

            // Führt die Volltextsuche in der aktuellen Webseite durch.
            string script = $"window.find('{searchText}', false, true)";
            await webView21.CoreWebView2.ExecuteScriptAsync(script);
        }

        // Event handler für das Suchergebnis
        void WebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            // Verarbeite das Suchergebnis hier
            // Das Ergebnis kann z.B. die Anzahl der gefundenen Treffer sein
            string searchResult = e.TryGetWebMessageAsString();
            Console.WriteLine("Suchergebnis: " + searchResult);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbxSearch.Text))
            {
                this.PerformSearch(this.tbxSearch.Text);
            }
        }
    }
}
