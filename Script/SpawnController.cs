using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] WaypointController _waypointController;
        [SerializeField] EnemyAsset _enemyAsset;

        public WaypointController WaypointController { get => _waypointController; set => _waypointController = value; }

        private void Start()
        {
            var enemy = Instantiate(_enemyAsset.EnemyPrefab, transform.position, Quaternion.identity);
            enemy.Waypoint = _waypointController.ListWaypoint[0];
        }
    }

}