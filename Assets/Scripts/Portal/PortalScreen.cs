using JetBrains.Annotations;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отвечает за окно портала(предложение спустится в инст и наоборот)
/// </summary>
public class PortalScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _descriptionField;
    
    [UsedImplicitly]
    public void TurnOffPanel()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(PortalSettings portalSettings)
    {
        _descriptionField.text = portalSettings.ScreenDescription;
    }
}