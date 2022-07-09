using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClick : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonPress()
    {
        GameManager.instance.moneyTotal += (GameManager.instance.skeletonCount)*(GameManager.instance.clickPower * GameManager.instance.clickMult);
        GameManager.instance.playerXP += ((GameManager.instance.skeletonCount) * (GameManager.instance.clickPower * GameManager.instance.clickMult));

    }

}
