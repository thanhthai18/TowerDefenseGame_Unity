using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class TowerController : MonoBehaviour
    {
        [SerializeField] TowerAsset _towerAsset;
        [SerializeField] private CircleCollider2D _vison;

        private int _damage;
        private EnemyController _taget;
        private Coroutine _shootCoroutine;

        public bool IsLockTarger => _taget != null;

        private void Start()
        {
            _towerAsset = Instantiate(_towerAsset);
            _vison.radius = _towerAsset.towerData.VisionRadius;
            _damage = _towerAsset.towerData.Damege;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //xem co phai enemy no trigger vao tam ban ko, neu co thi sinh ra cai mui ten va set muc tieu va dame
            if (IsLockTarger) return;
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _taget = collision.gameObject.GetComponent<EnemyController>();
                var projectile = Instantiate(_towerAsset.towerData.ProjectilePrefab, transform.position, Quaternion.identity).GetComponent<ProjectileController>();
                projectile.SetupProjectile(_taget, _damage);
            }
        }
        private void Handle_Event_OnDeath()
        {
            StopCoroutine(IEShoot);
        }

        private IEnumerator IEShoot()
        {
            var wait = new WaitForSecondsRealtime(_towerAsset.towerData.ShootIntervalTime);
            var projectile = Instantiate(_towerAsset.towerData.ProjectilePrefab, transform.position, Quaternion.identity);

        }
    }


}