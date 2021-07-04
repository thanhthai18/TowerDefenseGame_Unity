using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerGame;
using UnityEngine;

public class Canvas_MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtGold;
    [SerializeField] private TextMeshProUGUI _txtLife;

    private void Start()
    {
        _txtGold.SetText($"Gold: {GameController.Instance.LevelData.Gold}");
        _txtLife.SetText($"Life: {GameController.Instance.LevelData.Life}");

        GameController.Instance.Event_UpdateGold += Handle_Event_UpdateGold;
        GameController.Instance.Event_UpdateLife += Handle_Event_UpdateLife;
    }

    private void Handle_Event_UpdateGold(int gold)
    {
        _txtGold.SetText($"Gold: {gold}");
    }

    private void Handle_Event_UpdateLife(int life)
    {
        _txtLife.SetText($"Life: {life}");
    }
}
