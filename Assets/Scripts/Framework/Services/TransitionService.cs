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

        private Coroutine m_TransitionCoroutine = null;

        public Coroutine StartTransition()
        {
            m_TransitionCoroutine = StartCoroutine(StartTransition_Coroutine());
            return m_TransitionCoroutine;
        }

        public Coroutine EndTransition()
        {
            m_TransitionCoroutine = StartCoroutine(EndTransition_Coroutine());
            return m_TransitionCoroutine;
        }

        public IEnumerator StartTransition_Coroutine()
        {
            m_TransitionCanvas.gameObject.SetActive(true);

            m_Animator.SetTrigger(START_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);

            OnTransitionEnd?.Invoke();
        }

        public IEnumerator EndTransition_Coroutine()
        {
            m_Animator.SetTrigger(END_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);

            m_TransitionCanvas.gameObject.SetActive(false);

            OnTransitionEnd?.Invoke();
        }
    }
}
