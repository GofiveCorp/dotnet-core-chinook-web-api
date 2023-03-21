using static MyChinook_Utility.Enum.RequestType;

namespace MyChinook_Web.Models.Responses
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
