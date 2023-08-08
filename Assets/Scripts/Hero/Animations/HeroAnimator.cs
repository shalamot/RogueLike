using UnityEngine;

namespace Hero.Animations
{
    public sealed class HeroAnimator : MonoBehaviour
    {
        private const int MoveState = 1;
        private const int IdleState = 0;

        [SerializeField] 
        private Animator _animator;

        private static readonly int _state = Animator.StringToHash("State");

        public void PlayMove() => _animator.SetInteger(_state, MoveState);

        public void PlayIdle() => _animator.SetInteger(_state, IdleState);
    }
}