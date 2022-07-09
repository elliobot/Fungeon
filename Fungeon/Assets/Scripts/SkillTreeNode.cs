using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

using TMPro;



public class SkillTreeNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool unlocked = false;
    public Toggle thisSkill;
    public Toggle neededSkill;
    public string tooltipInfo;
    public TMP_Text tooltipText;
    public GameObject tooltipBody;
    public GameObject skillArea;



    // Update is called once per frame
    void Update()
    {
        tooltipText.text = tooltipInfo;
        RectTransform rt = skillArea.GetComponent(typeof(RectTransform)) as RectTransform;

        if (neededSkill.isOn)
        {
            thisSkill.transform.localScale = new Vector3 (3.3f, 3.3f, 3.3f);

        }
        else
        {
            thisSkill.transform.localScale = new Vector3 (0, 0, 0);

        }


        if (neededSkill.isOn && GameManager.instance.skillPoints >=1 && unlocked == false)
        {
            thisSkill.interactable = true;
        }
        else
        {
            thisSkill.interactable = false;

        }
        rt.sizeDelta = new Vector2(0, 0 + (100*(GameManager.instance.playerLevel - GameManager.instance.skillPoints)));
    }
    public void notebook()
    {
        GameManager.instance.skillMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillPoints -= 1;
    }
    public void pencil()
    {
        GameManager.instance.skillMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillPoints -= 1;
    }
    public void eraser()
    {
        GameManager.instance.clickMult += 1f;
        unlocked = true;
        GameManager.instance.skillPoints -= 1;
        

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipBody.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipBody.SetActive(false);
    }
    public void unlock()
    {

        unlocked = true;


    }
}
