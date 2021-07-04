using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private EnemyController _enemy;
        private int _damage;

        
        public int Damage { get; set; }
        public EnemyController Enemy { get => _enemy; set => _enemy = value; }

        private void Update()
        {
            if (Enemy == null) return;

            //di chuyen enemy
            var direction = Enemy.transform.position - transform.position;
            transform.Translate(_speed * direction.normalized * Time.deltaTime);
            
        }

        public void SetupProjectile(EnemyController taget, int damage)
        {
            Enemy = taget;
            _damage = damage;
            var direction = Enemy.transform.position - transform.position;
            var newRotation = Quaternion.FromToRotation(transform.right, direction).eulerAngles;
            var oldRotation = transform.rotation;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //bool IsCorrectTarget = Enemy.gameObject.GetInstanceID() == collision.gameObject.GetInstanceID();
                //if (IsCorrectTarget)
                //{
                    Enemy.TakeDamage(_damage);
                    Destroy(gameObject);
                //}
                
            }
        }
    }
}