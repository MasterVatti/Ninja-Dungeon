using Assets.Scripts.Managers.ScreensManager;

public class InformationScreenContext : BaseContext
{
    public InformationScreenContext(string title, string message)
    {
        Title = title;
        Message = message;
    }
    public string Title;
    public string Message;
}