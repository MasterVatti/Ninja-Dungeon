using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот) и обработку кнопки Yes
/// </summary>
public class PortalScreen : BaseScreenWithContext<PortalContext>
{
    [SerializeField]
    private Text _descriptionField;
    private string _sceneName;
    private Vector3 _teleportPosition;
    
    [UsedImplicitly]
    public void TurnOffPanel()
    {
         MainManager.ScreenManager.CloseTopScreen();
    }
    
    public override void ApplyContext(PortalContext context)
    {
        _descriptionField.text = context.Description;
        _sceneName = context.SceneName;
        _teleportPosition = context.TeleportPosition;
    }
    
    public void OnClick()
    {
        MainManager.Player.transform.position = _teleportPosition;
        MainManager.ScreenManager.CloseTopScreen();
        MainManager.LoadingController.StartLoad(_sceneName);
    }

    public override void Initialize(ScreenType screenType)
    {
        ScreenType = screenType;
    }
}