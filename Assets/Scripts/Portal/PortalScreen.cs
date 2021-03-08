using Assets.Scripts.Managers.ScreensManager;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот)
/// </summary>
public class PortalScreen : BaseScreenWithContext<PortalContext>
{
    [SerializeField]
    private TMP_Text _descriptionField;
    [SerializeField]
    private PortalOkButtonHandler _okButton;
    
    [UsedImplicitly]
    public void TurnOffPanel()
    {
        ScreenManager.Instance.CloseTopScreen();
    }
    
    public override void ApplyContext(PortalContext context)
    {
        _descriptionField.text = context.Description;
        _okButton.Initialize(context.SceneName);
    }

    public override void Initialize(ScreenType screenType)
    {
        ScreenType = screenType;
    }
}