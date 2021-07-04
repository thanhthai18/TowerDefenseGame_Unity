using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEnum;

namespace TowerGame
{
    [Serializable]
    public class Tower 
    {
        [SerializeField]  private ETowerType _towerType;
        [SerializeField] private int _cost;
        [SerializeField] private int _sellCost;
        [SerializeField] private int _level;
        [SerializeField] private int _damege;
        [SerializeField] private float _visionRadius;
        [SerializeField] private Sprite _towerSprite;
        [SerializeField] TowerAsset _upgradeTower;
        [SerializeField] GameObject _towerFrefab;
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] IEnumerator _shootIntervalTime;


        public ETowerType TowerType { get => _towerType; set => _towerType = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public int SellCost { get => _sellCost; set => _sellCost = value; }
        public int Level { get => _level; set => _level = value; }
        public int Damege { get => _damege; set => _damege = value; }
        public Sprite TowerSprite { get => _towerSprite; set => _towerSprite = value; }
        public TowerAsset UpgradeTower { get => _upgradeTower; set => _upgradeTower = value; }
        public GameObject TowerFrefab { get => _towerFrefab; set => _towerFrefab = value; }

        public bool CanUpgrade => _upgradeTower != null; // day chi la get

        public float VisionRadius { get => _visionRadius; set => _visionRadius = value; }
        public GameObject ProjectilePrefab { get => _projectilePrefab; set => _projectilePrefab = value; }
        public IEnumerator ShootIntervalTime { get => _shootIntervalTime; set => _shootIntervalTime = value; }
    }
}
          