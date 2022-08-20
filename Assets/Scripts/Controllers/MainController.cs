using Entities;
using UnityEngine;
using Views;

namespace Controllers
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private int _maxNumberIce;
        [SerializeField] private Ice _ice;
        [SerializeField] private UIGameView uiGameView;

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
            uiGameView.PrintNumberOfAttempts(_numberIce);
        }
        
        private void DecreaseNumberIce()
        {
            _numberIce -= 1;
            if (_numberIce <= 0)
                uiGameView.GameOver();
            uiGameView.PrintNumberOfAttempts(_numberIce);
        }
    }
}
