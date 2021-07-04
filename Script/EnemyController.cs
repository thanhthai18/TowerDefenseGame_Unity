using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Waypoint _waypoint;
        [SerializeField] private EnemyAsset _enemyAsset;

        private int _attackDamage;
        private float _speed;
        private int _health;
        private float _closeRange = 0.01f;

        public Waypoint Waypoint { get => _waypoint; set => _waypoint = value; }
        public int Health 
        { get => _health; 
            private set
            {
                _health = value;
                if (_health <= 0) Destroy(gameObject);
            }
        }

        public event Action Event_OnDeath;

        private void Start()
        {
            _enemyAsset = Instantiate(_enemyAsset);
            _attackDamage = _enemyAsset.AttackDamage;
            _speed = _enemyAsset.Speed;
            Health = _enemyAsset.Health;
            _closeRange = _enemyAsset.CloseRange;
        }

        private void Update()
        {
            // Lay khoang cach voi waypoint, distance nghia la khoang cach
            var distance = Vector2.Distance(transform.position, _waypoint.transform.position);
            var isClose = distance <= _enemyAsset.CloseRange;

            //xem co gan waypoint do ko?
            if (isClose)
            {
                // Xet xem waypont do co phai waypoint cuoi ko?
                if (_waypoint.IsEndWaypoint)
                {
                    // Tru life va destroy enemy di
                    GameController.Instance.UpdateLife(-_enemyAsset.AttackDamage);
                    Destroy(gameObject);
                }
                else
                {
                    _waypoint = _waypoint.NextWaypoint;
                }
            }
            else
            {
                var direction = _waypoint.transform.position - transform.position;
                transform.Translate( direction.normalized * _enemyAsset.Speed * Time.deltaTime);//normalized de toc do vector no smooth
                
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

    }
}