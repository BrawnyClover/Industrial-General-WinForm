using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Facebook;
using HtmlAgilityPack;
using System.Diagnostics;


namespace industrialGeneral_wform
{
    public partial class Form1 : Form
    {
        bool flag = false;
        private const string AppId = "908632959248840";
        private Uri _loginUrl;
        private const string _ExtendedPermissions = "user_about_me,publish_stream,offline_access";

        public Form1()
        {
            InitializeComponent();
        }
        public void getCourceMenu(string url)
        {
            System.Windows.Forms.HtmlDocument doc = null; // HtmlDocument 오브젝트

            //for (int i = 198; i <= 210; i++)
            //{
            //string url = "http://www.facebook.com";

            browser.Navigate(url); // 이동
                                   //var webGet = new Htmlweb();

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents(); // 웹페이지 로딩이 완료될 때 까지 대기
            }
            Stopwatch sw = new Stopwatch();
            bool flag = false;
            int cnt = 0;
            while (true)
            {
                Application.DoEvents();
                if (flag == false)
                {
                    sw.Start();
                    flag = true;
                }
                if (sw.ElapsedMilliseconds > 2000)
                {
                    textBox2.Text = sw.ElapsedMilliseconds.ToString()+" : "+cnt.ToString();
                    ScrollToBottom();
                    sw.Stop();
                    sw.Reset();
                    flag = false;
                    if (++cnt > 10) break;
                }
            }
            doc = browser.Document as System.Windows.Forms.HtmlDocument;
            //HtmlElementCollection options = doc.GetElementsByTagName("title");

            //}

        }
        private void getHtml()
        {
            HtmlElement elem;
            if (browser.Document != null)
            {
                HtmlElementCollection elems = browser.Document.GetElementsByTagName("html");
                if (elems.Count == 1)
                {
                    elem = elems[0];
                    string pageSource = elem.OuterHtml;
                    string pageSource2 = elem.InnerHtml;
                    textBox1.Text = pageSource + "\n" + pageSource2;

                }
            }
        }
        private void ScrollToBottom()
        {
            // MOST IMP : processes all windows messages queue
            Application.DoEvents();

            if (browser.Document != null)
            {
                browser.Document.Window.ScrollTo(0, browser.Document.Body.ScrollRectangle.Height);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            getCourceMenu(showUrl.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("aaa.txt");
            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getHtml();
        }
    }
}
