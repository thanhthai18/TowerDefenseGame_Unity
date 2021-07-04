using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private LevelAsset _lvlAsset;
        [SerializeField] private Level _levelData;

        private static GameController _instance;
        public static GameController Instance
        {
            get
            {
                return _instance;
            }
        }

        public Level LevelData { get => _levelData; set => _levelData = value; }


        public event Action<int> Event_UpdateGold;
        public event Action<int> Event_UpdateLife;

        private void Awake()
        {
            _instance = this;
            LevelData = _lvlAsset.level;
        }

        private void Start()
        {

        }

        public void UpdateGold(int gold)
        {
            LevelData.Gold += gold;
            Event_UpdateGold?.Invoke(_levelData.Gold);
        }

        public void UpdateLife(int life)
        {
            LevelData.Life += life;
            Event_UpdateLife?.Invoke(_levelData.Life);
        }
    }
  
}
