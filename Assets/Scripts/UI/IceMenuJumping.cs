using System;
using UnityEngine;
using Random = System.Random;

public class IceMenuJumping : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private float _timeJumping;

    private float _time=0f;
    private Random random;

    private void Start()
    {
        random = new Random((int)_timeJumping);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > _timeJumping)
        {
            _time = 0f;
            PlayAnim(random.Next(0, _animators.Length));
        }
    }

    private void PlayAnim(int i)
    {
        _animators[i].SetBool("Trigger",true);
    }
}
