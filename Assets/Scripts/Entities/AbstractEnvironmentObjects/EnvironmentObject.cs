using System;
using UnityEngine;

namespace Entities.AbstractEnvironmentObjects
{
    public abstract class EnvironmentObject : MonoBehaviour
    {
        [SerializeField] private float _offcetY;

        public float OffcetY => _offcetY;
    }
}