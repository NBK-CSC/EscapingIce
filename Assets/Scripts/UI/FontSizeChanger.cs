using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FontSizeChanger : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private float _ratio;

        private void Start()
        {
            _label.fontSize =(int)(Screen.height / _ratio);
        }
    }
}
