using System;
using System.Collections;
using UnityEngine;

namespace Artifax.Framework
{
    public class TransitionService : MonoBehaviour
    {
        [SerializeField]
        private Animator m_Animator;

        [SerializeField]
        private Canvas m_TransitionCanvas;

        private const string START_TRANSITION_TRIGGER = "Start";
        private const string END_TRANSITION_TRIGGER = "End";

        public Action OnTransitionEnd;

        private const float m_TransitionSafeTime = 0.5f;


        public IEnumerator StartTransition()
        {
            m_TransitionCanvas.gameObject.SetActive(true);

            m_Animator.SetTrigger(START_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength + m_TransitionSafeTime);

            OnTransitionEnd?.Invoke();
        }

        public IEnumerator EndTransition()
        {
            m_Animator.SetTrigger(END_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength + m_TransitionSafeTime);

            m_TransitionCanvas.gameObject.SetActive(false);

            OnTransitionEnd?.Invoke();
        }
    }
}
