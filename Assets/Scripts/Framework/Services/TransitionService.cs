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

        [SerializeField]
        private int m_StartTransitionState = Animator.StringToHash("Start");

        [SerializeField]
        private int m_EndTransitionState = Animator.StringToHash("End");


        public IEnumerator StartTransition()
        {
            m_TransitionCanvas.gameObject.SetActive(true);

            m_Animator.Play(m_StartTransitionState);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);
        }

        public IEnumerator EndTransition()
        {
            m_Animator.Play(m_EndTransitionState);
            yield return null;
            float animationLength = m_Animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength);

            m_TransitionCanvas.gameObject.SetActive(false);
        }
    }
}
