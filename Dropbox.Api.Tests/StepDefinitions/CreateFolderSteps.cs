using FluentAssertions;
using TechTalk.SpecFlow;
using TestDropboxApi.ApiFacade;
using TestDropboxApi.DataModels;
using TestDropboxApi.Helpers;

namespace Dropbox.Api.Tests.StepDefinitions
{
    [Binding]
    public class CreateFolderSteps
    {
        [Given(@"I send reqest to create a folder")]
        public void GivenISendReqestToCreateAFolder()
        {
            var response=new DropboxApi().CreateFileFolder("/Test1234Test/Test4");
            response.EnsureSuccessful();
            ContextHelper.AddToContext("LastApiResponse", response);
        }

        [Then(@"I  should get my folderin list of folders")]
        public void ThenIShouldGetMyFolderinListOfFolders()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>();
            filesList.Should().NotBeNull();
            filesList.Entries.Should().Contain(el=>el.Name=="Test1234Test");
        }

        [Given(@"I send request to delete folder")]
        public void GivenISendRequestToDeleteFolder()
        {
            var response=new DropboxApi().DeleteFileFolder("/Test1234Test");
            response.EnsureSuccessful();
        }

        [Then(@"I should not get my folderin list of folders")]
        public void ThenIShouldNotGetMyFolderinListOfFolders()
        {
            var apiResponse = ContextHelper.GetFromContext<ApiResponse>("LastApiResponse");
            var filesList = apiResponse.Content<FileListResponseDto>();
            filesList.Should().NotBeNull();
            filesList.Entries.Should().NotContain(el => el.Name == "Test1234Test");
        }




    }
}