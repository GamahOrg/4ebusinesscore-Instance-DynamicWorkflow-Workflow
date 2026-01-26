namespace _4EPlatform.Infrastructure.Helpers
{
    public interface IResponseHelper
    {
        ResponseDTO SavedSuccessfully(string message);
        ResponseDTO SavedSuccessfully(dynamic result, string message);
        ResponseDTO Exception();
        ResponseDTO FailedToSave(string message);

        ResponseDTO FailedToSave(dynamic result);

        ResponseDTO NotFound(string message);
        ResponseDTO AlreadyExists(string message);
        ResponseDTO RetrievedSuccessfully(dynamic result, string message);
        ResponseDTO RetrievedSuccessfully(dynamic result, string message, ref ResponseDTO responseDto);
    }
}