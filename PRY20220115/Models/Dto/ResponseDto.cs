namespace PRY20220115.Models.Dto
{
    public class ResponseDto
    {
        public bool Success { get; set; } = true;

        public object? Result { get; set; }

        public string? Message { get; set; }

        public List<string>? ErrorMessages { get; set; }
    }
}
