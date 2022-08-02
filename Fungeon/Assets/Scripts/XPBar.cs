using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class XPBar : MonoBehaviour
{

    public TMP_Text levelText;
    public float xpScaler = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "LVL: " + GameManager.instance.playerLevel;

        GameManager.instance.XPSlider.value = GameManager.instance.playerXP;
        if (GameManager.instance.XPSlider.value >= GameManager.instance.XPSlider.maxValue)
        {
            GameManager.instance.XPSlider.value = 0;
            GameManager.instance.playerLevel += 1;
            GameManager.instance.skillPoints += 1;
            GameManager.instance.maxXP *= xpScaler;
            GameManager.instance.minXP = GameManager.instance.playerXP;
            GameManager.instance.XPSlider.minValue = GameManager.instance.playerXP;
            GameManager.instance.XPSlider.maxValue = GameManager.instance.maxXP;
        }                                           
    }
}
