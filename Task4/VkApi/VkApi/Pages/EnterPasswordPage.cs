using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class EnterPasswordPage : Form
    {
        private ITextBox PasswordTextBox => ElementFactory.GetTextBox(By.XPath("//*[@name='password']"), nameof(PasswordTextBox));
        private IButton ContinueButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), nameof(ContinueButton));

        public EnterPasswordPage() : base(By.XPath("//*[@class='vkc__EnterPasswordNoUserInfo__content']"), nameof(EnterPasswordPage)) { }

        public void InputPasswordInTextBox(string password)
        {
            PasswordTextBox.State.WaitForEnabled();
            PasswordTextBox.ClearAndType(password);
        }

        public void ClickOnContinueButton() => ContinueButton.WaitAndClick();
    }
}