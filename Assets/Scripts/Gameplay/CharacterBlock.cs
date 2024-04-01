using Artifax.Framework;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    public class CharacterBlock : MonoBehaviour
    {
        [SerializeField]
        private LayerMask ColorBlockLayer;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(ColorBlockLayer.LayersMatch(collision.gameObject.layer))
            {
                //Change color
            }
        }
    }
}
