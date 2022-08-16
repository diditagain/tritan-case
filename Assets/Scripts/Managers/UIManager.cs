using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Button increaseSpeedButton, decreaseSpeedButton;
    [SerializeField] TextMeshProUGUI goldText, diamondText, totalValuetext;
    private int goldCount = 0, diamondCount = 0, totalValue = 0;

    private void Awake()
    {
        if (instance == null) { instance= this; }
        increaseSpeedButton.onClick.AddListener(SpeedUpButtonClicked);
        decreaseSpeedButton.onClick.AddListener(SlowDownButtonClicked);
    }



    private void SpeedUpButtonClicked()
    {
        GameEvents.instance.SpeedUpCharacter();
    }

    private void SlowDownButtonClicked()
    {
        GameEvents.instance.SlowDownCharacter();
        Debug.Log("hello from UI Manager");
    }

    public void CollectibleAcquired(CollectibleType type)
    {
        if (type == CollectibleType.Gold)
        {
            totalValue += 5;
            goldCount++;
        }
        else if (type == CollectibleType.Diamond)
        {
            diamondCount++;
            totalValue += 10;
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        goldText.text = "Gold: " + goldCount;
        diamondText.text = "Diamond: " + diamondCount;
        totalValuetext.text = "Total Value: " + totalValue;
    }


}
