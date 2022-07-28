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
        public float skilloffenceChance = 0f;
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
        public float minXP = 0f;
        public float maxXP = 0f;
        public Slider XPSlider;
        public Slider cooldownSlider;
        public bool[] skillTree = new bool[] { false, false, false, false, false, false, false, false, false, false };
        public bool[] offskillTree = new bool[] { false, false, false, false, false, false, false, false, false, false };

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
        public GameObject skills1;
        public GameObject skills2;
        public Transform parentGameObj;


    [Header("Upgrade Costs")]
        public float click1 = 0f;
        public float click2 = 0f;
        public float skel1 = 0f;
        public GameObject skillupgrades;
        public GameObject offskillupgrades;

    [Header("Save Settings")]
        public GameObject savedText;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        LoadPlayer();

        
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
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        StartCoroutine(ToggleSavedText(1));
    }
    public void LoadPlayer()
    {
        playerData data = SaveSystem.LoadPlayer();

        moneyTotal = data.moneyTotal;
        jokePower =     data.jokePower;
        skeletonCount = data.skeletonCount;
        offended =      data.offended;
        offenceChance = data.offenceChance;
        playerXP =      data.playerXP;
        minXP =      data.minXP;
        maxXP =      data.maxXP;
        playerLevel =   data.playerLevel;
        skillPoints =   data.playerLevel;
        skillCount =    data.skillCount;
        offenceCount =  data.offenceCount;
        cleanCount =    data.cleanCount;
        jokeSpeed =     data.jokeSpeed;
        autoclickUpgrade = data.autoclickUpgrade;
        click1 = data.click1;
        click2 = data.click2;
        skel1 = data.skel1;
        skillTree = data.skillTree;
        offskillTree = data.offskillTree;
        DeleteAllSkeletons();

        
        for (int i = 0; i < skeletonCount; i++)
        {
            CreateSkeleton();
        }

        

        Toggle thisToggle;
        int j = 0;
        foreach ( Transform item in skillupgrades.transform)
        {
            if (item.tag == "skillnode")
            {
                thisToggle = item.GetComponent<Toggle>();


                if (skillTree[j])
                {
                    thisToggle.interactable = true;
                    thisToggle.isOn = true;
                    thisToggle.transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
                }
                else
                {
                    thisToggle.isOn = false;
                    thisToggle.interactable = true;

                }
                j++;
            }
            
        }
        j = 0;
        foreach (Transform item in offskillupgrades.transform)
        {

            if (item.tag == "skillnode")
            {
                thisToggle = item.GetComponent<Toggle>();


                if (offskillTree[j])
                {
                    thisToggle.interactable = true;
                    thisToggle.isOn = true;
                    thisToggle.transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
                }
                else
                {
                    thisToggle.isOn = false;
                    thisToggle.interactable = true;

                }
                j++;
            }
        }
        resetXPBar();

        closeMenus();
    }
    public void DeleteAllSkeletons()
    {
        GameObject[] boneBoys;
        boneBoys = GameObject.FindGameObjectsWithTag("Skeleton");

        foreach (GameObject o in boneBoys)
        {
            Destroy(o);
        }
    }

    public void CreateSkeleton()
    {
        float randY = UnityEngine.Random.Range(0.04f, -0.17f);
        var position = new Vector3(UnityEngine.Random.Range(-1.5f, 1.5f), randY, randY);
        var newSkele = Instantiate(GameManager.instance.skeleton, position, Quaternion.identity);
        newSkele.transform.parent = parentGameObj;
        newSkele.transform.localScale = new Vector3(1, 1, 1);
    }
    public void closeMenus()
    {
        skills1.transform.localScale = new Vector3(0, 0, 0);
        skills2.transform.localScale = new Vector3(0, 0, 0);
    }
    public IEnumerator ToggleSavedText(float delay)
    {
        
            yield return new WaitForSeconds(delay);
            savedText.SetActive(true);

            yield return new WaitForSeconds(delay);
            savedText.SetActive(false);
        
    }
    public void resetXPBar()
    {
        XPSlider.minValue = minXP;
        XPSlider.maxValue = maxXP;
        XPSlider.value = playerXP;
    }
}
