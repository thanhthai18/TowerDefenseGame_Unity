using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnum;

namespace TowerGame
{
    public class BuildPlaceController : MonoBehaviour
    {
        [SerializeField]
        private TowerUIController _towerUIController;
        [SerializeField]
        private ETowerType _towerType;
        [SerializeField]
        private List<TowerAsset> _listTowerAssets = new List<TowerAsset>();
        [SerializeField]
        private GameObject _sale;
        [SerializeField]
        private bool _toggleActive;
        [SerializeField]
        private GameObject _tower;


        private Tower _towerData;
        private TowerAsset _currentTowerAsset;

        public event Action Event_SellTower;

        private void Awake()
        {
            _towerUIController.gameObject.SetActive(false);
        }

        private void ToggleSelect()
        {
            Debug.Log("BuildPlaceController.ToggleSelect()");
            _toggleActive = !_towerUIController.gameObject.activeSelf;
            _towerUIController.gameObject.SetActive(_toggleActive);

            _towerUIController.ShowTowerUI(_towerType);
        }
        private void Handle_Event_TouchObject(int instanceId)
        {
            if (instanceId != gameObject.GetInstanceID())
            {
                if (_toggleActive)
                {
                    Debug.Log($"{name}Unselect this tower...");
                    ToggleSelect();
                }
                return;
            }
            ToggleSelect();
            //if (instanceId == 9999) ToggleSelect();
        }

        private void Handle_OnTowerSelected(int towerIndex)
        {
            if (_towerType != ETowerType.None) return;
            Debug.Log($"Event_TowerSelected {_towerType}");

            _currentTowerAsset = _listTowerAssets[towerIndex - 1];
            _towerData = _currentTowerAsset.towerData;
            SpawnTower();
       
        }
        public void SpawnTower()
        {
            _towerType = _towerData.TowerType;
            var towerPrefab = _towerData.TowerFrefab;
            _tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            _tower.transform.SetParent(transform);
            if (_toggleActive)
                ToggleSelect();
            _sale.gameObject.SetActive(false);

            GameController.Instance.UpdateGold(-_towerData.Cost);
        }
        public void DeleteTower()
        {//bat lai bang sale
            _sale.gameObject.SetActive(true);
            // tat UI build
            ToggleSelect();
            // huy
            Destroy(_tower);
            //set lai tower type
            _towerType = ETowerType.None;
            
        }

        private void Handle_SelectedUI()
        {
            Debug.Log($"{name}Unselect this tower UI...");
            ToggleSelect();

            return;
        }

        private void Handle_Event_TowerSold()
        {
            SellTower();
        }
        public void SellTower()
        {
            DeleteTower();
            GameController.Instance.UpdateGold(_towerData.SellCost);
        }

        private void Handle_Event_TowerUpgrade()
        {
            UpgradeTower();
        }

        [ContextMenu("UpgradeTower")]
        public void UpgradeTower()
        {
            //Check xem co du tien ko
            if (GameController.Instance.LevelData.Gold < _towerData.Cost)
            {
                Debug.LogError("Connot upgrade... Not enought gold...");
                return;
            }
            //Check xem tower co upgrade duoc k
            if (!_towerData.CanUpgrade)
            {
                Debug.Log("Cannot upgrade... max level...");
                return;
            }
            //Xuly
            Debug.Log("Let's upgrade tower!");
            _currentTowerAsset = _currentTowerAsset.towerData.UpgradeTower;
            _towerData = _currentTowerAsset.towerData;
            DeleteTower();
            SpawnTower();
            Debug.Log($"Upgrade to tower{_currentTowerAsset.name}");
        }

        private void OnEnable()
        {
            _towerUIController.Event_TowerSelected += Handle_OnTowerSelected;
            TouchController.Event_TouchObject += Handle_Event_TouchObject;
            TouchController.Event_SelectUI += Handle_SelectedUI;
            _towerUIController.Event_TowerSold += Handle_Event_TowerSold;
            _towerUIController.Event_TowerUpgrade += Handle_Event_TowerUpgrade;
        }
        private void OnDisable()
        {
            _towerUIController.Event_TowerSelected -= Handle_OnTowerSelected;
            TouchController.Event_TouchObject -= Handle_Event_TouchObject;
            TouchController.Event_SelectUI -= Handle_SelectedUI;
            _towerUIController.Event_TowerSold -= Handle_Event_TowerSold;
            _towerUIController.Event_TowerUpgrade -= Handle_Event_TowerUpgrade;
        }




    }
}

