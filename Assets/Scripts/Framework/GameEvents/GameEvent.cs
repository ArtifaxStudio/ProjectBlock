using System.Collections.Generic;
using UnityEngine;

namespace Artifax.Framework
{
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = ArtifaxScriptablePaths.GAME_EVENT_SCRIPTABLE_PATH + "Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> m_EventListeners =
            new List<GameEventListener>();

        public void Raise()
        {
            for (int i = m_EventListeners.Count - 1; i >= 0; i--)
                m_EventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!m_EventListeners.Contains(listener))
                m_EventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (m_EventListeners.Contains(listener))
                m_EventListeners.Remove(listener);
        }
    }

    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<GameEventListener<T>> m_EventListeners =
            new List<GameEventListener<T>>();

        public void Raise(T value)
        {
            for (int i = m_EventListeners.Count - 1; i >= 0; i--)
                m_EventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(GameEventListener<T> listener)
        {
            if (!m_EventListeners.Contains(listener))
                m_EventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener<T> listener)
        {
            if (m_EventListeners.Contains(listener))
                m_EventListeners.Remove(listener);
        }
    }
}
