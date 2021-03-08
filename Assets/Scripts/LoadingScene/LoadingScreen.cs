using UnityEngine;
using UnityEngine.UI;

namespace LoadingScene
{
    /// <summary>
    /// Класс отвечает за окно загрузки меджу сценами.
    /// </summary>
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField]
        private Slider _loadingProgress;

        private void Update()
        {
            _loadingProgress.value = LoadingController.Instance.LoadingProgress;
        }
    }
}