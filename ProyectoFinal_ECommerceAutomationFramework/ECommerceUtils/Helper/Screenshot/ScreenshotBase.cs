using OpenQA.Selenium;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Screenshot
{
    public class ScreenshotBase
    {
        public static void TakeScreenshot(IWebDriver driver, string fullpath)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(fullpath);
        }

    }
}
