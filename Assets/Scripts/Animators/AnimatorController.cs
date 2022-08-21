using System;
using Models;
using UnityEngine;

namespace Animators
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private Ice _ice;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _ice = GetComponent<Ice>();
        }

        private void OnEnable()
        {
            _ice.Broken += Break;
        }

        private void OnDisable()
        {
            _ice.Broken -= Break;
        }

        private void Break()
        {
            if (_ice.IsOnSurface)
                _animator.SetTrigger("Break");
        }
    }
}
