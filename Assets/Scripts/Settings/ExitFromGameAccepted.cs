using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Онончательный выход из игры
    /// </summary>
    public class ExitFromGameAccepted : MonoBehaviour
    {
        public void OnClick()
        {
            Application.Quit();
        }
    }
}
