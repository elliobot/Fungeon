using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    [Header("Money Settings")]
        public float moneyTotal = 0f;
        public float clickPower = 1f;
        public float CPS = 0f;
        public float skillMult = 0f;


    [Header("Text Fields")]
        public Text moneyText;
        public Text skillPointsText;
        public Text upgrade1Text;
        public Text upgrade2Text;


    [Header("XP Settings")]
        public float playerXP = 0f;
        public float playerLevel = 0f;
        public float skillPoints = 0f;
        public float levelXP = 0f;
        public Slider XPSlider;

    [Header("Player Settings")]
        public GameObject player;

    [Header("Sprite Settings")]
        public GameObject skeleton;
    
    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = moneyTotal.ToString();

        if (skillPoints > 0)
        {
            skillPointsText.gameObject.SetActive(true);
            skillPointsText.text = skillPoints.ToString();
        }
        else
        {
            skillPointsText.gameObject.SetActive(false);
        }
        moneyTotal = Mathf.Round(moneyTotal * 100f) / 100f;


        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            moneyTotal += CPS * skillMult;
            playerXP += ((CPS* skillMult) * 100);

        }
    }
}
