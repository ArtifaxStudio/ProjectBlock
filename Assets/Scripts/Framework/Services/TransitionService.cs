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

        private readonly int START_TRANSITION_TRIGGER = Animator.StringToHash("Start");
        private readonly int END_TRANSITION_TRIGGER = Animator.StringToHash("End");

        public Coroutine StartTransition()
        {
            return StartCoroutine(StartTransition_Coroutine());
        }

        public Coroutine EndTransition()
        {
            return StartCoroutine(EndTransition_Coroutine());
        }

        public IEnumerator StartTransition_Coroutine()
        {
            m_TransitionCanvas.gameObject.SetActive(true);

            m_Animator.SetTrigger(START_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
        }

        public IEnumerator EndTransition_Coroutine()
        {
            m_Animator.SetTrigger(END_TRANSITION_TRIGGER);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);

            m_TransitionCanvas.gameObject.SetActive(false);
        }
    }
}
