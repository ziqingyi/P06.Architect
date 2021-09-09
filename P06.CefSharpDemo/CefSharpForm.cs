using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using CefSharp;
using CefSharp.WinForms;

namespace P06.CefSharpDemo
{
    public partial class CefSharpForm : Form
    {

        public ChromiumWebBrowser ChromeBrowser;
        //private CefCustomObject 


        public CefSharpForm()
        {
            InitializeComponent();


            CefSettings settings = new CefSettings(); 
            string page = "https://google.com";

            Cef.Initialize(settings);

            ChromeBrowser = new ChromiumWebBrowser(page);

            // Add it to the form and fill it to the form window
            this.Controls.Add(ChromeBrowser);
            ChromeBrowser.Dock = DockStyle.Fill;

            //Allow the use of local resources in the browser
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            ChromeBrowser.BrowserSettings = browserSettings;


        }


    private void CefSharpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
