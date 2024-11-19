using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artifax.ProjectBlock.Gameplay
{
    [CreateAssetMenu(fileName ="NewLevelsGroup", menuName = PBScriptablePaths.GAMEPLAY_SCRIPTABLE_PATH + "Levels Groups")]
    public class LevelsGroup : ScriptableObject
    {
        public string GroupName;
        public List<LevelConfiguration> Levels = new List<LevelConfiguration>();
    }
}
