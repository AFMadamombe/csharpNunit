using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRefineryDemo.Extensions
{
    public static class WebDriverExtensons
    {
        public static IWebElement FindShadowRootElelment(this IWebDriver Driver,
                                                         string[] Selectors)
        {
            IWebElement root = null;

            foreach (var selector in Selectors)
            {
                root = (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript("return argument[0].querySelector(arguments[1].shadowRoot", root, selector);
            }

            return root;
        }
    }
}
