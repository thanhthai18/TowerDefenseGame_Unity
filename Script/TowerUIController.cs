using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEnum;

namespace TowerGame
{
    public class TowerUIController : MonoBehaviour
    {
        public event Action<int> Event_TowerSelected;
        public event Action Event_TowerSold;
        public event Action Event_TowerUpgrade;
        [SerializeField] RectTransform _pnlTowerSelect;
        [SerializeField] RectTransform _pnlArcher;


        public void OnBtnTowerClicked(int towerIndex)
        {
            Debug.Log($"OnBtnTowerClicked({towerIndex})");
            Event_TowerSelected?.Invoke(towerIndex);
        }

        public void HideAllMenus()
        {
            _pnlTowerSelect.gameObject.SetActive(false);
            _pnlArcher.gameObject.SetActive(false);
        }

        public void ShowTowerUI(ETowerType towerType)
        {
            HideAllMenus();
            switch (towerType)
            {
                case ETowerType.None:
                    _pnlTowerSelect.gameObject.SetActive(true);
                    break;
                case ETowerType.Archer:
                    _pnlArcher.gameObject.SetActive(true);
                    break;
                case ETowerType.Soldier:

                    break;
                case ETowerType.Mage:

                    break;
                case ETowerType.Artilery:

                    break;
                default: break;
            }
        }

        public void OnBtnSkillClicked()
        {
            Debug.Log("Skill");
        }

        public void OnBtnUpgradeClicked()
        {
            Debug.Log("Upgrade");
            Event_TowerUpgrade?.Invoke();
        }

        public void OnBtnSellClicked()
        {
            Debug.Log("Sell");
            Event_TowerSold?.Invoke();
        }
    }
}

