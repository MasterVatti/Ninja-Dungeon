using Assets.Scripts.Managers.ScreensManager;
using Door;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот) и обработку кнопки Yes
/// </summary>
[RequireComponent(typeof(Animator))]
public class PortalScreen : DungeonScreenTransition
{
    [SerializeField]
    private int _energyCost;
    [SerializeField]
    private TextMeshProUGUI _textEnertyCost;

    private PortalAnimatorController _portalAnimatorController;
    
    private void Start()
    {
        var animator = GetComponent<Animator>();
        _portalAnimatorController = new PortalAnimatorController(animator);

        _textEnertyCost.text = _energyCost.ToString();
        
        _portalAnimatorController.ChangeButtonColor(MainManager.EnergyManager.HasEnoughEnergy(_energyCost));
    }
    
    [UsedImplicitly]
    public override void OnClick()
    {
        if (MainManager.EnergyManager.HasEnoughEnergy(_energyCost))
        {
            TransitionStage();
        }
        else
        {
            MainManager.ScreenManager.CloseTopScreen();
            MainManager.ScreenManager.OpenScreen(ScreenType.InsufficientResources);
        }
    }
    
    public override void Initialize(ScreenType screenType)
    {
        ScreenType = screenType;
    }
    
    protected override void TransitionStage()
    {
        base.TransitionStage();
        
        MainManager.EnergyManager.DecreaseEnergy(_energyCost);
    }
    
    
}