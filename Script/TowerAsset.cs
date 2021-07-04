using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    [CreateAssetMenu(fileName = "TowerAsset", menuName = "ConfigData/TowerAsset")]
    public class TowerAsset : ScriptableObject
    {    
        public Tower towerData;
    }
}

