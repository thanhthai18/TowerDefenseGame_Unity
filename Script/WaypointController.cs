using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerGame
{
    public class WaypointController : MonoBehaviour
    {
        [SerializeField] private List<Waypoint> _listWaypoint = new List<Waypoint>();

        public List<Waypoint> ListWaypoint { get => _listWaypoint; set => _listWaypoint = value; }

        // Ham noi cac diem
        [ContextMenu("SetupWaypoints")]
        private void SetupWaypoints()
        {
            //Lay cac component co kieu Waypont
            // Convert array do sang List ( dung linQ)

            ListWaypoint = GetComponentsInChildren<Waypoint>().ToList();
            for (int waypointIndex = 0; waypointIndex < ListWaypoint.Count - 1; waypointIndex++)
            {
                var nextIndex = waypointIndex + 1;
                var nexWaypoint = ListWaypoint[nextIndex];
                var currentWaypoint = ListWaypoint[waypointIndex];
                currentWaypoint.NextWaypoint = nexWaypoint;
            }
            ListWaypoint[ListWaypoint.Count-1].IsEndWaypoint = true;
        }
    }
}