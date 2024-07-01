using EasyAutomationFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyAutomationBOT
{
    public class AutomationWeb
    {
        public void StartClick()
        {
            Web web = new Web();
            int totalTime = (int)new TimeSpan(24, 0, 0).TotalMilliseconds;
            Stopwatch stopWatch = new Stopwatch();

            web.StartBrowser(TypeDriver.GoogleChorme);
            web.Navigate("https://orteil.dashnet.org/cookieclicker/");

            web.Click(TypeElement.Id, "langSelect-EN");
            stopWatch.Start();

            while (stopWatch.ElapsedMilliseconds <= totalTime)
            {
                web.Click(TypeElement.Id,"bigCookie");
                Thread.Sleep(500);
            }

            web.CloseBrowser();
        }
    }
}
