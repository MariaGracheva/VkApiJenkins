using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class NewsPage : Form
    {
        private IButton ProfileButton => ElementFactory.GetButton(By.Id("l_pr"), nameof(ProfileButton));

        public NewsPage() : base(By.Id("ui_rmenu_news"), nameof(NewsPage)) { }

        public void ClickOnProfileButton()
        {
            AqualityServices.Browser.Refresh();
            ProfileButton.WaitAndClick();
        }
    }
}