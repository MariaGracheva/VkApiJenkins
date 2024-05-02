using Aquality.Selenium.Browsers;
using Framework.Constants;
using Framework.TestData;
using Framework.Utils;
using VkApi.Pages;

namespace VkApi.Tests
{
    [NUnit.Extension.DependencyInjection.DependencyInjectingTestFixture]
    public class VkApiTestCase : BaseTest
    {
        private readonly MainPage MainPage;
        private readonly EnterPasswordPage EnterPasswordPage;
        private readonly NewsPage NewsPage;
        private readonly ProfilePage ProfilePage;

        public VkApiTestCase(MainPage MainPage,
            EnterPasswordPage EnterPasswordPage,
            NewsPage NewsPage,
            ProfilePage ProfilePage)
        {
            this.MainPage = MainPage;
            this.EnterPasswordPage = EnterPasswordPage;
            this.NewsPage = NewsPage;
            this.ProfilePage = ProfilePage;
        }

        [Test]
        public void Test()
        {
            AqualityServices.Logger.Info("Шаг 1. [UI] Перейти на сайт https://vk.com/");
            Assert.IsTrue(MainPage.State.WaitForDisplayed(), $"The page '{nameof(MainPage)}' is not displayed");

            AqualityServices.Logger.Info("Шаг 2. [UI] Авторизоваться.");
            MainPage.InputLoginInTextBox(TestDataManager.GetValue<string>("LoginForTextBox"));
            MainPage.ClickOnSignInButton();
            EnterPasswordPage.State.WaitForDisplayed();
            EnterPasswordPage.InputPasswordInTextBox(TestDataManager.GetValue<string>("PasswordForTextBox"));
            EnterPasswordPage.ClickOnContinueButton();
            Assert.IsTrue(NewsPage.State.WaitForDisplayed(), $"The page '{nameof(NewsPage)}' is not displayed");

            AqualityServices.Logger.Info("Шаг 3.[UI] Перейти на Мою страницу.");
            NewsPage.ClickOnProfileButton();
            Assert.IsTrue(ProfilePage.State.WaitForDisplayed(), $"The page '{nameof(ProfilePage)}' is not displayed");

            AqualityServices.Logger.Info("Шаг 4.[API] Cоздать запись со случайно сгенерированным текстом на стене.");
            var textForPostOnWall = RandomUtil.GenerateRandomString(TestDataManager.TextForPostOnWallLength);
            var postResponse = VkApiUtils.PostOnWall(textForPostOnWall);
            var postId = postResponse.Response.PostId;

            AqualityServices.Logger.Info("Шаг 5.[UI] Убедиться, что на стене появилась запись с нужным текстом от правильного пользователя.");
            Assert.That(ProfilePage.GetPostElementText(postId.ToString(), ApiParameters.OwnerId).Contains(textForPostOnWall),
                Is.True, "The post is not displayed or doesn't contain the expected text");

            AqualityServices.Logger.Info("Шаг 6.[API] Отредактировать запись - изменить текст и добавить любую картинку.");
            var updatedTextForPostOnWall = RandomUtil.GenerateRandomString(TestDataManager.TextForPostOnWallLength);
            var photoId = VkApiUtils.UpdatePostOnWall(postId, updatedTextForPostOnWall);

            AqualityServices.Logger.Info("Шаг 7.[UI] Убедиться, что изменился текст сообщения и добавилась загруженная картинка.");
            Assert.That(textForPostOnWall, Is.Not.EqualTo(updatedTextForPostOnWall), "The original text is not equal updated text");
            Assert.IsTrue(ProfilePage.PhotoOnWallIsDisplayed(photoId, ApiParameters.OwnerId, postId), $"Photo with id {photoId} is not displayed");

            AqualityServices.Logger.Info("Шаг 8.[API] Добавить комментарий к записи со случайным текстом.");
            var textForComment = RandomUtil.GenerateRandomString(TestDataManager.TextForPostOnWallLength);
            var postedComment = VkApiUtils.CreateCommentOnPost(postId, textForComment);
            ProfilePage.ClickOnShowNextCommentButton();
            var comment = VkApiUtils.GetComment(postedComment.Response.CommentId);

            AqualityServices.Logger.Info("Шаг 9.[UI] Убедиться, что к нужной записи добавился комментарий от правильного пользователя.");
            Assert.IsTrue(ProfilePage.PostElementIsDisplayed(comment.Id.ToString(), ApiParameters.OwnerId), $"The comment with id {comment.Id} is not displayed");
            Assert.IsTrue(ProfilePage.CommentFromOwnerUserIsDisplayed(comment.Id.ToString(), ApiParameters.OwnerId),
                $"The comment from {ApiParameters.OwnerId} is not displayed");

            AqualityServices.Logger.Info("Шаг 10.[UI] Через UI оставить лайк к записи.");
            ProfilePage.ClickOnLikeOnPostButton(postId.ToString(), ApiParameters.OwnerId);

            AqualityServices.Logger.Info("Шаг 11.[API] Через запрос к API убедиться, что у записи появился лайк от правильного пользователя.");
            var countLikesOfOwnerUser = VkApiUtils.GetLikeOnPost(postId).Response.Liked;
            Assert.IsTrue(countLikesOfOwnerUser == 1, "No likes from owner user");

            AqualityServices.Logger.Info("Шаг 12.[API] Через запрос к API удалить созданную запись.");
            VkApiUtils.DeletePost(postId);

            AqualityServices.Logger.Info("Шаг 13.[UI] Не обновляя страницу убедиться, что запись удалена.");
            Assert.IsTrue(ProfilePage.PostOnWallIsNotDisplayed(postId.ToString(), ApiParameters.OwnerId), $"post {postId} is not deleted");
        }
    }
}