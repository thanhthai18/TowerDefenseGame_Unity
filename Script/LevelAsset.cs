using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    [CreateAssetMenu(fileName = "LevelAsset", menuName = "ConfigData/LevelAsset")]
    public class LevelAsset : ScriptableObject
    {
        public Level level;
    }
    [Serializable]
    public class Level
    {
        [SerializeField] private int _gold;
        [SerializeField] private int _life;

        public int Gold { get => _gold; set => _gold = value; }
        public int Life { get => _life; set => _life = value; }

    }

}
