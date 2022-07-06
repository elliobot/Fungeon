using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class XPBar : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.XPSlider.value = GameManager.instance.playerXP;
        if (GameManager.instance.XPSlider.value >= GameManager.instance.XPSlider.maxValue)
        {
            
            GameManager.instance.XPSlider.value = 0;
            GameManager.instance.playerLevel += 1;
            GameManager.instance.skillPoints += 1;
            GameManager.instance.XPSlider.maxValue *= 2;
            GameManager.instance.XPSlider.minValue = GameManager.instance.playerXP;
        }
    }
}
