using System;
using Entities.Сhanging;
using UnityEngine;
using UnityEngine.Events;

namespace Entities
{
    [RequireComponent(typeof(Mover),typeof(Melter))]
    public class Ice : MonoBehaviour
    {
        [SerializeField] private float _distanceCheckGround;
        
        [SerializeField] private Transform _checkRightGroundRay;
        [SerializeField] private Transform _checkLeftGroundRay;

        private IceInput _iceInput;
        private Mover _mover;
        private BoxCollider _boxCollider;
        private bool _onSurfaceState;

        public event UnityAction OnBoardFell;
        public event UnityAction OnBoardFellOff;
        public event UnityAction Broken;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _boxCollider = GetComponent<BoxCollider>();
            
            _iceInput = new IceInput();
        }

        private void OnEnable()
        {
            _iceInput.Enable();
        }

        private void OnDisable()
        {
            _iceInput.Disable();
        }

        private void Start()
        {
            _onSurfaceState = false;
        }

        private void FixedUpdate()
        {
            if (IsLocateOnGround()!=_onSurfaceState)
                NotifySurfaceChanges();
            if (TryBecomePuddle())
                Broke();
            var valueAxisX = _iceInput.Ice.Move.ReadValue<float>();
            _mover.Move(new Vector3(valueAxisX, 0, 1));
        }

        private void NotifySurfaceChanges()
        {
            _onSurfaceState =!_onSurfaceState;
            if (_onSurfaceState)
                OnBoardFell?.Invoke();
            else
                OnBoardFellOff?.Invoke();
        }
        
        private bool TryBecomePuddle()
        {
            return _boxCollider.size.y <= 0f;
        }
        
        private bool IsLocateOnGround()
        {
            Ray rayRight = new Ray(_checkRightGroundRay.position, -_checkRightGroundRay.up);
            Ray rayLeft = new Ray(_checkLeftGroundRay.position, -_checkLeftGroundRay.up);
            return Physics.Raycast(rayRight, out RaycastHit hit1, _distanceCheckGround) ||
                   Physics.Raycast(rayLeft, out RaycastHit hit2, _distanceCheckGround);
        }

        public void Broke()
        {
            Broken?.Invoke();
        }
    }
}
