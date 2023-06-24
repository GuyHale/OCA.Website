using OCA.Website.Interfaces;

namespace OCA.Website.Helpers
{
    public static class ResponseHelpers
    {
        public static ICustomResponse ServerError<T>()  where T : ICustomResponse, new()
        {
            T response = new()
            {
                Success = false,
                ErrorMessages = new string[] { "Something has gone wrong, please try again!" }
            };
            return response;
        }
    }
}
