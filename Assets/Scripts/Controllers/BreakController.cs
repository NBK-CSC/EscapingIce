using Entities;
using UnityEngine;

namespace Controllers
{
    public class BreakController:MonoBehaviour
    {
        [SerializeField] private Ice _ice;
        
        public void MakeBreakIce()
        {
            _ice.Break();
        }
    }
}