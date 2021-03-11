using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using LoadingScene;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот) и обработку кнопки Yes
/// </summary>
public class PortalScreen : BaseScreenWithContext<PortalContext>
{
    [SerializeField] private TMP_Text _descriptionField;
    private string _sceneName;
    
    [UsedImplicitly]
    public void TurnOffPanel()
    {
        ScreenManager.Instance.CloseTopScreen();
    }
    
    public override void ApplyContext(PortalContext context)
    {
        _descriptionField.text = context.Description;
        _sceneName = context.SceneName;
    }
    
    public void OnClick()
    {
        ScreenManager.Instance.CloseTopScreen();
        LoadingController.Instance.StartLoad(_sceneName);
    }

    public override void Initialize(ScreenType screenType)
    {
        ScreenType = screenType;
    }
}