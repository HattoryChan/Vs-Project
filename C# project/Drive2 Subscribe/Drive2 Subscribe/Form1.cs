using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive2_Subscribe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrows1.Navigate("https://www.drive2.ru/r/moskvich/1183439/");
            //WebBrows1.Document.GetElementById("").InvokeMember("click");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.drive2.ru/r/nissan/490554535509492055/");
            request.Headers.Add(".AUI=_wfqzlwoyisJAAFxZTl19ibQ7n9gESfgI9TTFVW2UtfrlwtqQkRe; _DVAB=1; cmtchd=yes; .DVAB=1; _AFF=5; addruid=1sm52G1hB7S45eX8D83q9iM67i; bltsr=1; safeframe-test-cookie_1525523891266_47_1=test; _ga=GA1.2.794392820.1526965177; _ym_uid=1526965178797473655; rheftjdd=rheftjddVal; .PBIK=Aga528BAAACRAQAAAAAG8ezAQAADEgcAOkBAAATkAAAAAAFsBHHcWInShCZWNACZK-kwXegeHw; .UTZ=1529754160 -300; .AMET=Unkt3wf4Yh-SZND-vmVTJqeYhZBLVo9a8UXVJ2QZ_6JXHMAPJ-xqgRE8i-HPa-bcguOHU0bsxGDdy5ZYeluwLA; tmr_detect=1%7C1529823164126");

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        }
    }
}
