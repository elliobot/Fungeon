using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class XPBar : MonoBehaviour
{

    public TMP_Text levelText;

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
            levelText.text = "Level: " + GameManager.instance.playerLevel;
        }
    }
}
