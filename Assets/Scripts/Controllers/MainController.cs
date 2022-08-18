using Entities;
using UnityEngine;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private int _maxNumberIce;
        [SerializeField] private Ice _ice;
        [SerializeField] private UIController _UIController;

        private int _numberIce;
        
        private void OnEnable()
        {
            _ice.Broken += DecreaseNumberIce;
        }

        private void OnDisable()
        {
            _ice.Broken -= DecreaseNumberIce;
        }
        
        private void Start()
        {
            _numberIce = _maxNumberIce;
            _UIController.PrintNumberOfAttempts(_numberIce);
        }
        
        private void DecreaseNumberIce()
        {
            _numberIce -= 1;
            if (_numberIce <= 0)
                _UIController.GameOver();
            _UIController.PrintNumberOfAttempts(_numberIce);
        }
    }
}
