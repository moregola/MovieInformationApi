namespace MovieInformationApi.DTO
{
    public class SuccessResponseDTO<T> where T : class
    {
        public T Content { get; set; }
        public string Message { get; set; }
    }
}
