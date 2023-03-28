namespace Api.Application.DTO.Responses;

public class ServiceResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}