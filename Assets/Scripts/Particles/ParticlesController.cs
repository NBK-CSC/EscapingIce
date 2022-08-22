using System;
using Models;
using UnityEngine;

namespace Particles
{
    public class ParticlesController : MonoBehaviour
    {
        [SerializeField] private Ice _ice;
        [SerializeField] private ParticleSystem _meltParticle;
        [SerializeField] private ParticleSystem _splashParticle;

        private bool _isOnBoard;
        
        private void OnEnable()
        {
            _ice.OnBoardFell += SetTrueState;
            _ice.OnBoardFellOff+= SetFalseState;
        }

        private void OnDisable()
        {
            _ice.OnBoardFell-= SetTrueState;
            _ice.OnBoardFellOff-= SetFalseState;
        }

        private void Update()
        {
            if (_isOnBoard)
            {
                _meltParticle.Play();
                _splashParticle.Play();
            }
        }

        private void SetTrueState()
        {
            _isOnBoard = true;
        }
        
        private void SetFalseState()
        {
            _isOnBoard = false;
        }
    }
}