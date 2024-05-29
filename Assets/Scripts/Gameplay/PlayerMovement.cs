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

            float halfWidth = Screen.width / 2f;
            m_MoveDirection = context.ReadValue<float>();
            //m_MoveDirection -= halfWidth;
            //m_MoveDirection = Mathf.Sign(m_MoveDirection);
            Debug.Log($"{m_MoveDirection}");
        }

        private void FixedUpdate()
        {
            characterController.Move(m_MoveDirection);
        }
    }
}
