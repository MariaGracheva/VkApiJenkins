using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class MainPage : Form
    {
        private ITextBox LoginTextBox => ElementFactory.GetTextBox(By.Id("index_email"), nameof(LoginTextBox));
        private IButton SignInButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), nameof(SignInButton));

        public MainPage() : base(By.Id("index_login"), nameof(MainPage)) { }

        public void InputLoginInTextBox(string login) => LoginTextBox.ClearAndType(login);

        public void ClickOnSignInButton() => SignInButton.Click();
    }
}