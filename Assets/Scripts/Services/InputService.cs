using System;
using UnityEngine;

namespace Services
{
    public sealed class InputService : MonoBehaviour
    {
        public event Action<Vector3> OnMove;
        public event Action<Vector3> OnRift;
        public event Action OnAttack;
        
        private void Update() {
            var direction = Vector3.zero;
            
            if (Input.GetKey(KeyCode.A)) {
                direction += Vector3.left;
            }
            
            if (Input.GetKey(KeyCode.W)) {
                direction += Vector3.forward;
            }
            
            if (Input.GetKey(KeyCode.D)) {
                direction += Vector3.right;
            }
            
            if (Input.GetKey(KeyCode.S)) {
                direction += Vector3.back;
            }

            //if (direction != Vector3.zero) {
                OnMove?.Invoke(direction * Time.deltaTime);
            //}
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                OnRift?.Invoke(direction);
                //Debug.Log("leftshift");
            }
        }
    }
}