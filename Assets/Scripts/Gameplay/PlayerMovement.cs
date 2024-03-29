using UnityEngine;
using UnityEngine.InputSystem;

namespace Artifax.ProjectBlock
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController2D characterController;

        private float m_MoveDirection = 0f;
        private bool m_Jump = false;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            m_MoveDirection = context.ReadValue<float>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(!context.performed) 
                return;

            m_Jump = true;
        }

        private void FixedUpdate()
        {
            characterController.Move(m_MoveDirection, m_Jump);
            m_Jump = false;
        }
    }
}
