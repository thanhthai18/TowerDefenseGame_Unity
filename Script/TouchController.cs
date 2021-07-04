using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerGame
{
    /// <summary>
    /// Detect clicked gameobject
    /// </summary>
    public class TouchController : MonoBehaviour
    {
        private Camera _mainCamera;

        [SerializeField] private LayerMask _layerHitMask;
        [SerializeField] private int _layerUI;
        [SerializeField] private int _layerTowerUI;
        public static event Action<int> Event_TouchObject;
        public static event Action Event_SelectUI;

        private void Start()
        {
            _mainCamera = Camera.main; // lay ra camera co ten Main Camera
           
        }

        private void Update()
        {
            //Select UI
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                if(EventSystem.current.currentSelectedGameObject.layer == _layerUI)
                {
                    Event_SelectUI?.Invoke();
                    return;
                }
                else if(EventSystem.current.currentSelectedGameObject.layer == _layerTowerUI)
                {
                    return;
                }
                
            }

            if (Input.GetMouseButtonDown(0))
            {
                // Lay vi tri touch tren screen space, convert sang world spcae
                // Raycast nhu cai tia tu camera chieu xuong man hinh de biet vi tri
                // Tra ve 1 RaycastHit2D
                var hit = Physics2D.Raycast(_mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, _layerHitMask);
                if (hit.collider != null)
                {
                    Debug.Log($"Hit {hit.collider.name}");
                    Event_TouchObject?.Invoke(hit.collider.gameObject.GetInstanceID());
                    //(GetInstanceID la 1 unique id do unity tu tao ra gan voi object)
                }
                //else Event_TouchObject?.Invoke(9999);
            }

        }

    }
}

