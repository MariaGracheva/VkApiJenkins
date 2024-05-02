using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Framework.ConfigManager;
using OpenQA.Selenium;

namespace VkApi.Pages
{
    public class ProfilePage : Form
    {
        private IButton ShowNextCommentButton => ElementFactory.GetButton(By.XPath("//*[contains(@class,'replies_next_label')]"), nameof(ShowNextCommentButton));

        private ILabel GetPostElementById(string elementId, string ownerId) => ElementFactory.GetLabel(By.Id($"post{ownerId}_{elementId}"), "ElementOnWall");

        private ILabel GetPhotoOnWall(long photoId, string ownerId, long postId) =>
            ElementFactory.GetLabel(By.XPath($"//*[@id ='post{ownerId}_{postId}']//*[contains(@href,'{photoId}')]"), "PhotoOnWall");

        private ILabel GetOwnerIdInComment(string elementId, string ownerId) => ElementFactory.GetLabel
            (By.XPath($"//*[@id='post{ownerId}_{elementId}']//*[@data-from-id='{ownerId}']"), "OwnerIdInComment");

        private IButton GetLikeOnPostButton(string postId, string ownerId)
        {
            return ElementFactory.GetButton(By.XPath($"//*[@id='post{ownerId}_{postId}']//*[contains(@class,'PostButtonReactionsContainer')]"), "LikeButton");
        }

        public ProfilePage() : base(By.Id("wall_tabs"), nameof(ProfilePage)) { }

        public string GetPostElementText(string elementId, string ownerId) => GetPostElementById(elementId, ownerId).Text;

        public void ClickOnShowNextCommentButton()
        {
            if (ShowNextCommentButton.State.WaitForDisplayed())
            {
                ShowNextCommentButton.Click();
            }
        }

        public bool CommentFromOwnerUserIsDisplayed(string elementId, string ownerId) => GetOwnerIdInComment(elementId, ownerId).State.WaitForDisplayed();

        public bool PostElementIsDisplayed(string elementId, string ownerId) => GetPostElementById(elementId, ownerId).State.WaitForDisplayed();

        public void ClickOnLikeOnPostButton(string postId, string ownerId) => GetLikeOnPostButton(postId, ownerId).WaitAndClick();

        public bool PhotoOnWallIsDisplayed(long photoId, string ownerId, long postId) => GetPhotoOnWall(photoId, ownerId, postId).State.WaitForDisplayed();

        public bool PostOnWallIsNotDisplayed(string postId, string ownerId)
        {
            return GetPostElementById(postId, ownerId).State.WaitForNotDisplayed(TimeSpan.FromSeconds(ConfigDataManager.TimeoutFromSeconds()));
        }
    }
}