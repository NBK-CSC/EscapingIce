using System;
using UnityEngine;

namespace Entities.AbstractEnvironmentObjects
{
    public abstract class EnvironmentObject : MonoBehaviour
    {
        [SerializeField] private float offsetY;

        public float OffsetY => offsetY;
    }
}