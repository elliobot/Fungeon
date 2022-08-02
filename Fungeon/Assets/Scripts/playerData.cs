using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class playerData
{

    public float moneyTotal;
    public float jokePower;
    public float jokeMult;
    public float skeletonCount;
    public float clickMult;
    public float offended;
    public float offenceChance;
    public float playerXP;
    public float minXP;
    public float maxXP;
    public float playerLevel;
    public float skillPoints;
    public float levelXP ;
    public float jokeSpeed;
    public bool autoclickUpgrade;
    public float click1;
    public float click2;
    public float skel1;
    public float offChance1;
    public bool[] skillTree;
    public bool[] offskillTree;
    public string saveDate; 
    public playerData (GameManager player)
    {

        moneyTotal = player.moneyTotal;
        jokePower = player.jokePower;
        skeletonCount = player.skeletonCount;
        offended = player.offended;
        offenceChance = player.offenceChance;
        playerXP = player.playerXP;
        minXP = player.minXP;
        maxXP = player.maxXP;
        playerLevel = player.playerLevel;

        jokeSpeed = player.jokeSpeed;
        autoclickUpgrade = player.autoclickUpgrade;
        click1 = player.click1;
        click2 = player.click2; 
        skel1  = player.skel1;
        skillTree = player.skillTree;
        offskillTree = player.offskillTree;
        saveDate = player.saveDate;

    }

}
