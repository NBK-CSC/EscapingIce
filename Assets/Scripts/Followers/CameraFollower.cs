using UnityEngine;

namespace Followers
{
    public class CameraFollower : Follower
    {
        public Transform TargetTransform
        {
            get => _targetTransform;
            set => _targetTransform = value;
        }
        private void FixedUpdate()=>Move(Time.fixedDeltaTime);
    }
}