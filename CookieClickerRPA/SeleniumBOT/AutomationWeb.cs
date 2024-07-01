using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace SeleniumBOT
{
    public class AutomationWeb
    {
        private IWebDriver driver;
        private WebDriverWait webDriverWait;
        private ChromeOptions options;

        public AutomationWeb()
        {
            options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            webDriverWait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
        }

        public void StartClick()
        {
            Stopwatch stopWatch = new Stopwatch();
            int totalTime = (int)new TimeSpan(24, 0, 0).TotalMilliseconds;
            IWebElement web = null;
            driver.Navigate().GoToUrl("https://orteil.dashnet.org/cookieclicker/");

            web = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id("langSelect-EN")));
            web.Click();
            stopWatch.Start();

            while (stopWatch.ElapsedMilliseconds <= totalTime)
            {
                try
                {
                    web = webDriverWait.Until(ExpectedConditions.ElementExists(By.Id("bigCookie")));
                    web.Click();

                    Thread.Sleep(500);
                }
                catch { }
            }

            stopWatch.Stop();
            driver.Quit();
        }
    }
}
