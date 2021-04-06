using System;
using Assets.Scripts.Managers.ScreensManager;
using TMPro;
using UnityEngine;

namespace Settings
{
    public class SettingsScreen : BaseScreenWithContext<SettingsContext>
    {
        /*[SerializeField]
        private TMP_Text _settingsDescription;*/

        public override void ApplyContext(SettingsContext context)
        {
            //_settingsDescription = new TextMeshPro();
            //_settingsDescription.text = context.firstSetting;
        }
        
        public override void Initialize(ScreenType screenType)
        {
            ScreenType = screenType;
            Debug.Log(screenType);
        }
        
        private void OnDestroy()
        {
            //DontDestroyOnLoad(this);
        }
    }
}
