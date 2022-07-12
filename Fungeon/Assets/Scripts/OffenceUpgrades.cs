using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffenceUpgrades : MonoBehaviour
{
    public Button thisButton;
    public float upgradeCost = 10;
    public float costMult = 2;
    public float clickUpgPower = 1;
    public Text upg1CostText;

    // Start is called before the first frame update
    void Start()
    {
        upg1CostText.text = upgradeCost.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        upgradeCost = Mathf.Round(upgradeCost * 100f) / 100f;
        if (GameManager.instance.offended >= upgradeCost)
        {
            thisButton.interactable = true;
        }
        else
        {
            thisButton.interactable = false; ;

        }

    }
    public void UpgradeOffChance()
    {
        if (GameManager.instance.offended >= upgradeCost)
        {
            GameManager.instance.offenceChance += clickUpgPower;
            GameManager.instance.offended -= upgradeCost;

            upgradeCost *= costMult;
            upg1CostText.text = upgradeCost.ToString();


        }
    }
}
