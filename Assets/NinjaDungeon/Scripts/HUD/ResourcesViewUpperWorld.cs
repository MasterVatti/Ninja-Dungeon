using HUD;

/// <summary>
/// Класс отвечает за HUDResource
/// </summary>
public class ResourcesViewUpperWorld : ResourceView
{
    protected override void Start()
    {
        _resources = MainManager.ResourceManager.GetResources();
        base.Start();
        MainManager.ResourceManager.OnResourceAmountChanged += OnResourceAmountChanged;
    }
    
    private void OnDestroy()
    {
        MainManager.ResourceManager.OnResourceAmountChanged -= OnResourceAmountChanged;
    }
}
