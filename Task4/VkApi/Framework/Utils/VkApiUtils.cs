using Aquality.Selenium.Browsers;
using Framework.ConfigManager;
using Framework.Constants;
using Framework.Exceptions;
using Framework.Factories;
using Framework.Models.Responses.Comment;
using Framework.Models.Responses.Error;
using Framework.Models.Responses.GetAdressforPhotoLoad;
using Framework.Models.Responses.GetComment;
using Framework.Models.Responses.GetLike;
using Framework.Models.Responses.LoadPhotoOnServer;
using Framework.Models.Responses.PostOnWall;
using Framework.Models.Responses.SavePhotoOnServer;
using Framework.TestData;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Framework.Utils
{
    public class VkApiUtils
    {
        private static RestClientOptions Options => new(ConfigDataManager.ApiUrl);

        private static string ErrorMessageKey => "error";

        public static PostOnWallResponse PostOnWall(string message)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.WallPostMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.Message, message);
            var response = restClient.Post(request);

            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<PostOnWallResponse>(response.Content)
                : throw new ApiException(errorMessage);
        }

        public static long UpdatePostOnWall(long postId, string message)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.UpdateWallPostMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.Message, message);
            request.AddParameter(ApiParameters.PostId, postId);

            var uploadUrl = GetUrlForPhotoLoad();
            var photo = LoadPhotoOnServer(uploadUrl);
            var savedPhoto = SavePhotoOnServer(photo.Server, photo.Photo, photo.Hash);

            request.AddParameter(ApiParameters.Attachments, ApiParameters.GetPhotoId(savedPhoto.OwnerId, savedPhoto.Id));

            var response = restClient.Post(request);
            var errorMessage = ValidateResponse(response);

            return errorMessage is null
                ? savedPhoto.Id
                : throw new ApiException(errorMessage);
        }

        public static PostCommentResponse CreateCommentOnPost(long postId, string message)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.CreateCommentMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.Message, message);
            request.AddParameter(ApiParameters.PostId, postId);
            var response = restClient.Post(request);
            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<PostCommentResponse>(response.Content)
                : throw new ApiException(errorMessage);
        }

        public static CommentItem GetComment(long commentId)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.GetCommentMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.CommentId, commentId);
            var response = restClient.Get(request);
            var errorMessage = ValidateResponse(response);
            var getCommentResponse = errorMessage is null
                ? JsonConvert.DeserializeObject<GetCommentResponse>(response.Content)
                : throw new ApiException(errorMessage);
            return getCommentResponse?.Response?.Items?.FirstOrDefault();
        }

        public static GetLikeResponse GetLikeOnPost(long postId)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.GetLikeOnPostMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.ItemId, postId);
            request.AddParameter(ApiParameters.Type.Key, ApiParameters.Type.Value);
            var response = restClient.Get(request);
            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<GetLikeResponse>(response.Content)
                : throw new ApiException(errorMessage);
        }

        public static void DeletePost(long postId)
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.DeletePostMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.PostId, postId);
            var response = restClient.Post(request);
            var errorMessage = ValidateResponse(response);
            if (errorMessage is not null)
            {
                throw new ApiException(errorMessage);
            }
        }

        private static string GetUrlForPhotoLoad()
        {
            using var restClient = new RestClient(Options);
            var request = RequestFactory.CreateRequest(ApiMethods.GetUrlforPhotoLoadMethod, ApiParameters.CommonParameters);

            var response = restClient.Get(request);
            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<GetUrlForPhotoLoadResponse>(response.Content).Response.UploadUrl
                : throw new ApiException(errorMessage);
        }

        private static LoadPhotoOnServerResponse LoadPhotoOnServer(string uploadUrl)
        {
            using var restClient = new RestClient(new RestClientOptions(uploadUrl));

            var request = RequestFactory.CreateRequest();

            request.AddHeader(ApiHeaders.MultipartContentType.Key, ApiHeaders.MultipartContentType.Value);
            request.AddFile(ApiParameters.Photo, TestDataManager.UploadFilePath);

            var response = restClient.Post(request);
            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<LoadPhotoOnServerResponse>(response.Content)
                : throw new ApiException(errorMessage);
        }

        private static SavePhotoOnServerData SavePhotoOnServer(long server, string photo, string hash)
        {
            using var restClient = new RestClient(Options);

            var request = RequestFactory.CreateRequest(ApiMethods.SavePhotoOnServerMethod, ApiParameters.CommonParameters);
            request.AddParameter(ApiParameters.Server, server);
            request.AddParameter(ApiParameters.Photo, photo);
            request.AddParameter(ApiParameters.Hash, hash);

            var response = restClient.Post(request);
            var errorMessage = ValidateResponse(response);
            return errorMessage is null
                ? JsonConvert.DeserializeObject<SavePhotoOnServerResponse>(response.Content).Response.FirstOrDefault()
                : throw new ApiException(errorMessage);
        }

        private static string ValidateResponse(RestResponse response)
        {
            ErrorResponse error = null;

            if (response.Content.Contains(ErrorMessageKey))
            {
                error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                AqualityServices.Logger.Error(error.Error.ErrorMsg);
                return error.Error.ErrorMsg;
            }

            return error is null && response.StatusCode.Equals(HttpStatusCode.OK)
                ? null
                : error.Error.ErrorMsg;
        }
    }
}