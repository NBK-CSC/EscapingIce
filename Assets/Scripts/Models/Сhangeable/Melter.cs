using UnityEngine;

namespace Models.Сhangeable
{
    [RequireComponent(typeof(BoxCollider))]
    public class Melter:MonoBehaviour
    {
        [SerializeField] private float _meltingFactor;
        [SerializeField] private Transform _movableContainer;
        
        private Vector3 _sizeBoxCollider;
        private Vector3 _centerBoxCollider;
        private Vector3 _movableContainerPosition;

        private BoxCollider _boxCollider;
        private Ice _ice;
        private bool _canMelt=false;
        
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _ice = GetComponent<Ice>();
        }
        
        private void OnEnable()
        {
            _ice.OnBoardFell += GivePermissionMelt;
            _ice.OnBoardFellOff += SetDefault;
        }

        private void OnDisable()
        {
            _ice.OnBoardFell -= GivePermissionMelt;
            _ice.OnBoardFellOff -= SetDefault;
        }
        
        private void Start()
        {
            _sizeBoxCollider = _boxCollider.size;
            _centerBoxCollider = _boxCollider.center;
            _movableContainerPosition = _movableContainer.localPosition;
        }
        
        private void FixedUpdate()
        {
            if (_canMelt)
                Melt();
        }

        private void GivePermissionMelt()
        {            
            _canMelt = true;
        }
        
        private void SetDefault()
        {   
            _canMelt = false;
            _boxCollider.size = _sizeBoxCollider;
            _boxCollider.center = _centerBoxCollider;
            _movableContainer.localPosition = _movableContainerPosition;
        }
        
        private void Melt()
        {
            _boxCollider.size += new Vector3(0, -_meltingFactor, 0);
            _boxCollider.center += new Vector3(0, _meltingFactor/2, 0);
            _movableContainer.position +=new Vector3(0, _meltingFactor, 0);
        }
    }
}