namespace Data.DTO;

public class BaseApiResponse
{
    public bool IsError { get; set; }
    public string? ErrorMessage { get; set; }
}