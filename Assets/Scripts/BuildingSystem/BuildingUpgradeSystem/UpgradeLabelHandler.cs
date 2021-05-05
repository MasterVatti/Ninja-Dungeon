using TMPro;
using UnityEngine;

namespace BuildingSystem.BuildingUpgradeSystem
{
    public static class UpgradeLabelHandler
    {
        public static void SetLabelText(GameObject label, string value)
        {
            var textMesh = label.GetComponent<TextMeshProUGUI>();
            textMesh.text = value;
        }
    }
}
