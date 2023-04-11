namespace Client.ViewModels;

public class RespondVM<Entity>
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
    public Entity? Data { get; set; }
}