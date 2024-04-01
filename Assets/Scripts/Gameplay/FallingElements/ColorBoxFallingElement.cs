using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class ColorBoxFallingElement : FallingElement
    {
        [SerializeField]
        protected ColorBoxFallingElementConfiguration m_Configuration;

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnTouchBoundaries()
        {
            base.OnTouchBoundaries();
        }

        protected override void OnTouchPlayer()
        {
            base.OnTouchPlayer();
        }
    }
}
