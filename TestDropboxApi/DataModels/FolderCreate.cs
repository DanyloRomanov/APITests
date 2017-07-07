using Newtonsoft.Json;

namespace TestDropboxApi.DataModels
{
    public class FolderCreate
    {

        public FolderCreate(string path)
        {
            Path = path;
            
        }
        [JsonProperty("path")]
        public string Path { get; set; } = string.Empty;

        [JsonProperty("autorename")]
        public bool Autorename { get; set; } 
    }
}