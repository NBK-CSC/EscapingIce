using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers
{
    public class IcesController : MonoBehaviour
    {
        [SerializeField] private int _amountIce;
        [SerializeField] private int _maxNumberIce;
        [SerializeField] private Ice _ice;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Button _button;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioBroken;
        [SerializeField] private Text _label;
        [SerializeField] private MainController _mainController;
    
        private int _numberIce;
        
        public event UnityAction<Ice> IceAppeared ;
        public event UnityAction<Ice> IceBroke;

        private void OnEnable()
        {
            _button.onClick.AddListener(MakeIceBroke);
            _ice.Broken += AppearIce;
            _ice.Broken += DecreaseNumberIce;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(MakeIceBroke);
            _ice.Broken -= AppearIce;
            _ice.Broken -= DecreaseNumberIce;
        }

        private void Start()
        {
            _numberIce = _maxNumberIce;
            AppearIce();
            DecreaseNumberIce();
        }

        private void MakeIceBroke()
        {
            _ice.Broke();
            _audioSource.PlayOneShot(_audioBroken,1f);
            IceBroke?.Invoke(_ice);
            DecreaseNumberIce();
        }
        
        private void AppearIce()
        {
            _ice.gameObject.SetActive(true);
            _ice.transform.position = _startPoint.position;
            IceAppeared?.Invoke(_ice);
        }
    
        private void DecreaseNumberIce()
        {
            _numberIce -= 1;
            if (_numberIce<=0)
                _mainController.Reset();
            _label.text = $"x{_numberIce}";
        }
    }
}
