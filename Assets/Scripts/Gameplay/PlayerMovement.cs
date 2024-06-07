using UnityEngine;
using UnityEngine.InputSystem;

namespace Artifax.ProjectBlock.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController2D characterController;

        private float m_MoveDirection = 0f;

        public void OnMove(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            m_MoveDirection = context.ReadValue<float>();
        }

        private void FixedUpdate()
        {
            characterController.Move(m_MoveDirection);
        }
    }
}
