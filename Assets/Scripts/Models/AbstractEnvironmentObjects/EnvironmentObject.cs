using UnityEngine;

namespace Models.AbstractEnvironmentObjects
{
    public abstract class EnvironmentObject : MonoBehaviour
    {
        [SerializeField] private float offsetY;

        public float OffsetY => offsetY;
    }
}