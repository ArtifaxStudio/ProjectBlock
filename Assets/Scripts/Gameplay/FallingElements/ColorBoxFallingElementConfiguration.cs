using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifax.ProjectBlock
{
    [CreateAssetMenu(fileName = "NewColorBoxFallingElementConfiguration", menuName = ASSET_PATH + "ColorBox")]
    public class ColorBoxFallingElementConfiguration : FallingElementConfiguration
    {
        [SerializeField]
        protected Color m_Color;

        public Color Color => m_Color;
    }
}
