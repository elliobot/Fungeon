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
    public enum OffenceOrClean { Offensive, Nautral, Clean }

    public OffenceOrClean OOC;

    // Update is called once per frame
    void Update()
    {
        tooltipText.text = tooltipInfo;

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

    }
    public void notebook()
    {
        GameManager.instance.jokeMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillCount++;
        GameManager.instance.skillPoints -= 1;
    }
    public void pencil()
    {
        GameManager.instance.jokeMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillCount++;
        GameManager.instance.skillPoints -= 1;
    }
    public void eraser()
    {
        GameManager.instance.jokeMult += 1f;
        unlocked = true;
        GameManager.instance.skillCount++;
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

        if (OOC == OffenceOrClean.Nautral)
        {
            GameManager.instance.cleanCount++;
        }
        else if (OOC == OffenceOrClean.Offensive)
        {
            GameManager.instance.offenceCount++;
        }
    }
}
