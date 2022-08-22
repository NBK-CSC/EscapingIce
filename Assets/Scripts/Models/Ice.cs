using Models.Сhangeable;
using UnityEngine;
using UnityEngine.Events;

namespace Models
{
    public enum BreakState
    {
        SelfBreak,
        Crash,
        Fell,
        Melt
    }

    [RequireComponent(typeof(Mover),typeof(Melter))]
    public class Ice : MonoBehaviour
    {
        [SerializeField] private float _distanceCheckGround;
        [SerializeField] private float _lateralMotionReductionFactor;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _checkRightGroundRay;
        [SerializeField] private Transform _checkLeftGroundRay;
        [SerializeField] private Renderer _renderer;
        
        private IceInput _iceInput;
        private Mover _mover;
        private BoxCollider _boxCollider;
        private bool _isOnSurface;
        private bool _isBroken;

        public bool IsOnSurface => _isOnSurface;

        public event UnityAction OnBoardFell;
        public event UnityAction OnBoardFellOff;
        public event UnityAction<BreakState> Broken;

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
            _isOnSurface = false;
        }

        private void FixedUpdate()
        {
            if (IsLocateOnGround()!=_isOnSurface)
                NotifySurfaceChanges();
            if (TryBecomePuddle())
                Break(BreakState.Melt);
            if (!_isBroken)
            {
                var valueAxisX = _isOnSurface ? _iceInput.Ice.Move.ReadValue<float>() : 0f;
                _mover.Move(new Vector3(valueAxisX * _lateralMotionReductionFactor, 0, 1));
            }
        }

        private void NotifySurfaceChanges()
        {
            _isOnSurface =! _isOnSurface;
            if (_isOnSurface)
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

        public void DisableRender()
        {
            _renderer.enabled=false;
        }

        public void SetDefault()
        {
            _isBroken = false;
            _renderer.enabled = true;
            transform.position = _startPoint.position;
        }

        public void Break(BreakState breakState)
        {
            if (_isBroken)
                return;
            Broken?.Invoke(breakState);
            _isBroken = true;
        }
    }
}
