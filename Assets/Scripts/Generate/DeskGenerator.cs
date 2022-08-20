using Controllers;
using Entities;
using Generate.AbstractGenerate;
using UnityEngine;

namespace Generate
{
    public class DeskGenerator : FollowerSerialGeneratorObjects<Desk>
    {
        [SerializeField] private IceController _iceController;
        
        private void OnEnable() => _iceController.IceBroken += Reset;
        private void OnDisable()=> _iceController.IceBroken -= Reset;
        
    }
}