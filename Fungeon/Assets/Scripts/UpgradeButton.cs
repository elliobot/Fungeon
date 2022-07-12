using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour
{
    [Header("Button Settings")]

    public Button thisButton;
    public float upgradeCost = 10;
    public float costMult = 2;
    public float clickUpgPower = 1;
    public Text upg1CostText;
    public Transform parentGameObj;

    // Start is called before the first frame update
    void Start()
    {
        upg1CostText.text = upgradeCost.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        upgradeCost = Mathf.Round(upgradeCost * 100f) / 100f;
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            thisButton.interactable = true;
        }
        else
        {
            thisButton.interactable = false; ;

        }

    }
    public void UpgradeClick()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.clickMult += clickUpgPower;
            GameManager.instance.moneyTotal -= upgradeCost;

            upgradeCost *= costMult;
            upg1CostText.text = upgradeCost.ToString();


        }
    }
    public void upgradeJokeSpeed()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.jokeSpeed *= clickUpgPower;
            GameManager.instance.moneyTotal -= upgradeCost;

            upgradeCost *= costMult;
            upg1CostText.text = upgradeCost.ToString();


        }
    }
    public void HireWriter()
    {
        if (GameManager.instance.moneyTotal >= upgradeCost)
        {
            GameManager.instance.moneyTotal -= upgradeCost;
            GameManager.instance.skeletonCount += 1f;

            upgradeCost *= costMult;
            upg1CostText.text = upgradeCost.ToString();
            float randY = Random.Range(-0.7f, -1f);
            var position = new Vector3(Random.Range(-1.4f, 1.6f), randY, randY);
            var newSkele = Instantiate(GameManager.instance.skeleton, position, Quaternion.identity);
            newSkele.transform.parent = parentGameObj;
            newSkele.transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
