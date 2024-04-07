
namespace Moonhotels.Hub.Application.Wrappers
{
    public class Response<T>
    {
        public Response(T data, string message = "")
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}