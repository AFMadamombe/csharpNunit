using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Threading;

namespace DataRefineryDemo
{
    class Program
    {

        //Create refernece for webdriver
        readonly IWebDriver driver = new ChromeDriver();
        //readonly IWebDriver driver = new FirefoxDriver();

        static void Main(string[] _)
        {
        }

        [SetUp]
        public void Initialise()
        {
            //Navigate to The Data Refinery page
            driver.Navigate().GoToUrl("https://integration.thedatarefinery.co.uk/");
            //driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestLogin()
        {

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            IWebElement refinery = (IWebElement)jse.ExecuteScript("return document.querySelector(\"body > data-refinery\")");
            IWebElement button = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"toolbar-menu\").shadowRoot.querySelector(\"a[href='/login']\")", refinery);
            button.Click();

            Thread.Sleep(3000);
            IWebElement page = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"#appHeaderLayout > iron-pages > login-page\")", refinery);

            IWebElement email = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"input[name='email']\")", page);
            email.SendKeys("data@thedatarefinery.co.uk");
            Thread.Sleep(2000);

            IWebElement password = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"input[name='password']\")", page);
            password.SendKeys("pass1234!");
            Console.WriteLine(password);

            Thread.Sleep(2000);

            IWebElement submit = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"form-button\")", page);
            submit.Click();

            Thread.Sleep(5000);
        }


        //[Test]
        public void TestTryItFOrFree()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            IWebElement refinery = (IWebElement)jse.ExecuteScript("return document.querySelector(\"body > data-refinery\")");
            IWebElement button = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"toolbar-menu\").shadowRoot.querySelector(\"a[href='/register']\")", refinery);
            button.Click();
            Thread.Sleep(5000);

        }

        //[Test]
        public void TestUploadFile()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;


            IWebElement refinery = (IWebElement)jse.ExecuteScript("return document.querySelector(\"body > data-refinery\")");
            IWebElement button = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"toolbar-menu\").shadowRoot.querySelector(\"a[href='/login']\")", refinery);
            button.Click();
            Thread.Sleep(3000);

            IWebElement page = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"#appHeaderLayout > iron-pages > login-page\")", refinery);
            IWebElement email = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"input[name='email']\")", page);
            email.SendKeys("data@thedatarefinery.co.uk");
            Thread.Sleep(2000);

            IWebElement password = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"input[name='password']\")", page);
            password.SendKeys("pass1234!");
            Console.WriteLine(password);

            Thread.Sleep(2000);

            IWebElement submit = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"form-button\")", page);
            submit.Click();



            IWebElement LoggedInpage = (IWebElement)jse.ExecuteScript("return arguments[0].shadowRoot.querySelector(\"#appHeaderLayout > app-header > toolbar-menu\")", refinery);
            IWebElement upload = (IWebElement)jse.ExecuteScript("return arguments[0]shadowRoot.querySelector(\"paper-tab[link name ='upload']\")", LoggedInpage);
            upload.Click();
            Thread.Sleep(6000);





        }


        [TearDown]
        public void CleanUp()
        {
            //Close the browser
            driver.Close();
            Console.WriteLine("Closed the browser");
        }
    }
}
