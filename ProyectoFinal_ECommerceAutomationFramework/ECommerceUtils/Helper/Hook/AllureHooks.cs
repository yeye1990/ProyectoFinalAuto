using System;
using System.IO;
using Allure.Net.Commons;
using OpenQA.Selenium;
using ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Screenshot;
using Reqnroll;

namespace ProyectoFinal_ECommerceAutomationFramework.ECommerceUtils.Helper.Hook
{
    [Binding]
    public class AllureHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public AllureHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        // Toma screenshot SOLO si el step falla y lo adjunta a Allure
        [AfterStep]
        public void TakeScreenshotOnError()
        {
            if (_scenarioContext.TestError == null)
                return;

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var screenshotsDir = Path.Combine(baseDir, "Screenshots");
            Directory.CreateDirectory(screenshotsDir);

            var fileName = $"step_error_{DateTime.Now:yyyyMMdd_HHmmssfff}.png";
            var fullPath = Path.Combine(screenshotsDir, fileName);

            ScreenshotBase.TakeScreenshot(_driver, fullPath);

            AllureApi.AddAttachment(
                fileName,
                "image/png",
                fullPath
            );
        }
    }
}

