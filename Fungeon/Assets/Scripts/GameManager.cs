using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    [Header("Money Settings")]
        public float moneyTotal = 0f;
        public float jokePower = 1f;
        public float jokeMult = 1f;
        public float skeletonCount = 1f;
        public float clickMult = 1f;
    
    [Header("Offence Settings")]
        public float offended = 0f;
        public float offenceChance = 0f;
        public TMP_Text offendedTextbox;

    [Header("Text Fields")]
        public TMP_Text moneyText;
        public Text skillPointsText;
        public Text upgrade1Text;
        public Text upgrade2Text;


    [Header("XP Settings")]
        public float playerXP = 0f;
        public float playerLevel = 0f;
        public float skillPoints = 0f;
        public float levelXP = 0f;
        public Slider XPSlider;
        public Slider cooldownSlider;

    [Header("Player Settings")]
        public int skillCount = 0;
        public int offenceCount = 0;
        public int cleanCount = 0;

    [Header("Player Settings")]
        public GameObject player;
        public float jokeSpeed = 1f;
        public bool autoclickUpgrade = false;

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
        if (moneyTotal >= 10000000)
        {
            moneyText.text = (Mathf.Round(moneyTotal * 100) / 100).ToString("G3");
        }
        else
        {
            moneyText.text = moneyTotal.ToString();
        }

        offendedTextbox.text = offended.ToString();

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
            moneyTotal += skeletonCount*(jokePower * jokeMult);
            playerXP += skeletonCount * (jokePower * jokeMult);

        }
    }
}
