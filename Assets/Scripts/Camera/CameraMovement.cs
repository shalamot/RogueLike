using UnityEngine;

namespace Camera
{
    public sealed class CameraMovement: MonoBehaviour
    {
        [SerializeField] 
        private Transform Following;
        
        [SerializeField] 
        private float _rotationAngleX;
        
        [SerializeField] 
        private float _distanceNear;
        
        [SerializeField] 
        private float _distanceFar;
        
        [SerializeField] 
        private float _offsetY;
        
        [SerializeField] 
        private float _speed;
        
        [SerializeField] 
        private float _excess;

        private Transform _transform;
        private float _distance;
        private bool _isFollowingNull;

        private void Start() {
            // _isFollowingNull = true;
            _transform = transform;
            _distance = _distanceFar;
        }

        private void LateUpdate() {
            if (_isFollowingNull) return;

            var rotation = Quaternion.Euler(_rotationAngleX, 0, 0);
                
            var position = Vector3.Lerp(_transform.position,
                rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition(), Time.deltaTime * _speed);
            
            _transform.rotation = rotation;
            _transform.position = position;
        }

        public void Follow(GameObject following) {
            Following = following.transform;
            _isFollowingNull = false;
        }

        public void ChangeView(bool near) => 
            _distance = near ? _distanceNear : _distanceFar;

        public void DismissCamera() => 
            _isFollowingNull = true;

        private Vector3 FollowingPointPosition() {
            var excess = _excess * _distance / _distanceFar;
            var followingPosition = Following.position + Following.forward * excess;
            followingPosition.y += _offsetY;
            return followingPosition;
        }
    }
}