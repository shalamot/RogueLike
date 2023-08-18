using System;
using Hero.Animations;
using Services;
using UnityEngine;

namespace Hero.Movement
{
    [RequireComponent(typeof(HeroAnimator))]
    public sealed class HeroMovement : MonoBehaviour
    {
        [SerializeField] 
        private InputService InputService;

        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _rotationSpeed;
        
        private Transform _transform;
        private HeroAnimator _animator;
        private CharacterController _characterController;

        private void Awake() {
            _transform = transform;
            _animator = GetComponent<HeroAnimator>();
        }

        private void OnEnable() {
            InputService.OnMove += OnMove;
            InputService.OnRift += OnRift;
            _characterController = GetComponent<CharacterController>();
        }

        private void OnDisable() {
            InputService.OnMove -= OnMove;
            InputService.OnRift -= OnRift;
        }

        private void OnMove(Vector3 direction) {
            //_transform.forward = direction;
            if (direction != Vector3.zero) {
                //_transform.position += direction * _speed;
                
                var currentRotation = _transform.rotation;
                var targetRotation = Quaternion.LookRotation(direction);
            
                _transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationSpeed * Time.deltaTime);
                
                direction.y = -0.5f;
                _characterController.Move(direction * _speed);
                _animator.PlayMove();
            }else {
                _animator.PlayIdle();
            }
        }

        private void OnRift(Vector3 direction) => _animator.PlayRift();
    }
}