using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class DisablerRender : MonoBehaviour
    {
        [SerializeField] private Ice _ice;
        [SerializeField] private float _timeCrash;
        [SerializeField] private float _timeFell;
        [SerializeField] private float _timeMelt;
        [SerializeField] private float _timeSelfBreak;

        private Dictionary<BreakState, float> _timeDelayBreak;

        private void Start()
        {
            _timeDelayBreak = new Dictionary<BreakState, float>
            {
                { BreakState.Crash, _timeCrash },
                { BreakState.Fell, _timeFell },
                { BreakState.Melt, _timeMelt },
                { BreakState.SelfBreak, _timeSelfBreak }
            };
        }

        private void OnEnable()
        {
            _ice.Broken += DisableRender;
        }

        private void OnDisable()
        {
            _ice.Broken -= DisableRender;
        }

        private void DisableRender(BreakState breakState)
        {
            StartCoroutine(DelayDisableRender(_timeDelayBreak[breakState]));
        }

        private IEnumerator DelayDisableRender(float time)
        {
            yield return new WaitForSeconds(time);
            _ice.DisableRender();
        }
    }
}