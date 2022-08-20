using Generate.AbstractGenerate;
using Models;
using Presenters;
using UnityEngine;

namespace Generate
{
    public class DeskGenerator : FollowerSerialGeneratorObjects<Desk>
    {
        [SerializeField] private IcePresenter icePresenter;
        
        private void OnEnable() => icePresenter.IceBroken += Reset;
        private void OnDisable()=> icePresenter.IceBroken -= Reset;
        
    }
}