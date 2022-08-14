using Entities;
using Generate.AbstractGenerate;
using UnityEngine;

namespace Generate
{
    public class DeskGenerator : FollowerSerialGeneratorObjects<Desk>
    {
        [SerializeField] private Ice _ice;
        
        private void OnEnable() => _ice.Broken += Reset;
        private void OnDisable()=> _ice.Broken -= Reset;
        
    }
}