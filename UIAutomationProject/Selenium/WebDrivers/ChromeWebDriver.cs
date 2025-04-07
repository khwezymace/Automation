﻿using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using UIAutomation.Core.Abstration;
using UIAutomation.Core.Runner;
using WebDriverManager.DriverConfigs.Impl;
namespace UIAutomation.Core.Selenium.WebDrivers
{
    public class ChromeWebDriver : IChromeWebDriver
    {
        readonly IGlobalProperties _iglobalProperties;
        public ChromeWebDriver()
        {
           _iglobalProperties = SpecFlowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
        }
        public IWebDriver GetChromeWebDriver()
        {
            IWebDriver iwebdriver;
            if (string.IsNullOrEmpty(_iglobalProperties.gridhuburl))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                iwebdriver = new ChromeDriver(GetOptions());
                iwebdriver.Manage().Window.Maximize();
            }
            else
            {
                iwebdriver = new RemoteWebDriver(new Uri(_iglobalProperties.gridhuburl), GetOptions());
            }
            return iwebdriver;
        }
        public ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extension=src/main/resources/chrome_load_stopper");
            options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("download.default_directory", _iglobalProperties.downloadedlocation);
            return options;
        }

    }

}

