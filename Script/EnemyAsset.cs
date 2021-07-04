using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TowerGame
{
    [CreateAssetMenu(fileName = "EnemyAsset", menuName = "ConfigData/EnemyAsset")]
    public class EnemyAsset : ScriptableObject
    {
        [SerializeField] private float _speed ;
        [SerializeField] private float _closeRange = 0.01f;
        [SerializeField] private int _attackDamage;
        [SerializeField] private int _health;
        [SerializeField] private EnemyController _enemyPrefab;

        public float Speed { get => _speed; set => _speed = value; }
        public float CloseRange { get => _closeRange; set => _closeRange = value; }
        public int AttackDamage { get => _attackDamage; set => _attackDamage = value; }
        public int Health { get => _health; set => _health = value; }
        public EnemyController EnemyPrefab { get => _enemyPrefab; set => _enemyPrefab = value; }
    }
}
