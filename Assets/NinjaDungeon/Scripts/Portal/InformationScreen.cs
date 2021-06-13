    using Assets.Scripts.Managers.ScreensManager;
using TMPro;
using UnityEngine;

public class InformationScreen : BaseScreenWithContext<InformationScreenContext>
{
    [SerializeField]
    private TextMeshProUGUI _title;
    [SerializeField]
    private TextMeshProUGUI _message;
    
    private ScreenType _screenType;

    public override void Initialize(ScreenType screenType)
    {
        _screenType = screenType;
    }

    
    public override void ApplyContext(InformationScreenContext context)
    {
        _title.text = context.Title;
        _message.text = context.Message;
    }

    public void OnClick()
    {
        MainManager.ScreenManager.CloseTopScreen();
    }
}