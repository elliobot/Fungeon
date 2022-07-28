using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour
{
    [Header("Button Settings")]

    public Button thisButton;
    public float costMult = 2;
    public float clickUpgPower = 1;
    public Text upg1CostText;
    private float upgradeCost;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "click1")
        {
            upgradeCost = GameManager.instance.click1;

        }
        else if (this.name == "click2")
        {
            upgradeCost = GameManager.instance.click2;
        }
        else if (this.name == "skel1")
        {
            upgradeCost = GameManager.instance.skel1;
        }
        upg1CostText.text = upgradeCost.ToString();
    
    }
    // Update is called once per frame
    void Update()
    {

        if (this.name == "click1")
        {
            upgradeCost = GameManager.instance.click1;

        }
        else if (this.name == "click2")
        {
            upgradeCost = GameManager.instance.click2;
        }
        else if (this.name == "skel1")
        {
            upgradeCost = GameManager.instance.skel1;
        }

        upgradeCost = Mathf.Round(upgradeCost * 100f) / 100f;
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            thisButton.interactable = true;
        }
        else
        {
            thisButton.interactable = false; ;

        }


        upg1CostText.text = upgradeCost.ToString();
    }
    public void UpgradeClick()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.clickMult += clickUpgPower;
            GameManager.instance.moneyTotal -= upgradeCost;

            upgradeCost *= costMult;
            GameManager.instance.click1 = upgradeCost;


        }
    }
    public void upgradeJokeSpeed()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.jokeSpeed *= clickUpgPower;
            GameManager.instance.moneyTotal -= upgradeCost;

            upgradeCost *= costMult;
            GameManager.instance.click2 = upgradeCost;

        }
    }
    public void HireWriter()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.moneyTotal -= upgradeCost;
            GameManager.instance.skeletonCount += 1f;

            upgradeCost *= costMult;
            GameManager.instance.skel1 = upgradeCost;

            GameManager.instance.CreateSkeleton();
        }
    }

}
