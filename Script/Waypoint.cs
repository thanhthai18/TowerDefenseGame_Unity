using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerGame
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Waypoint _nextWaypoint;
        [SerializeField] private Color _color;
        [SerializeField] private bool _isEndWaypoint;


        public Waypoint NextWaypoint { get => _nextWaypoint; set => _nextWaypoint = value; }
        public bool IsEndWaypoint { get => _isEndWaypoint; set => _isEndWaypoint = value; }




        // Ham nay chi de hien thi ko anh huong den game
        private void OnDrawGizmos()
        {
            if (NextWaypoint != null)
                Debug.DrawLine(transform.position, NextWaypoint.transform.position, _color);
        }
    }
}
