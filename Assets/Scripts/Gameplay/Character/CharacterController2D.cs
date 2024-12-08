using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Artifax.ProjectBlock.Gameplay
{
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxVelocity = 2f;
        [SerializeField] private Rigidbody2D m_Rigidbody2D;
        [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;
        [SerializeField] private LayerMask m_WhatIsGround;
        [SerializeField] private Transform m_GroundCheck;

        const float k_GroundedRadius = .2f;
        private bool m_Grounded;
        private bool m_FacingRight = true;
        private Vector3 m_Velocity = Vector3.zero;

        [Header("Events")]
        [Space]

        public UnityEvent OnLandEvent;

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        private void FixedUpdate()
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }

        public void Move(float direction)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded)
            {
                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(direction * m_MaxVelocity, m_Rigidbody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }
        }
    }
}
