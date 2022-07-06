using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillTreeNode : MonoBehaviour
{
    public bool unlocked = false;
    public Toggle thisSkill;
    public Toggle neededSkill;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        GameManager.instance.skillMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillPoints -= 1;
    }
    public void pen()
    {
        GameManager.instance.skillMult += 0.5f;
        unlocked = true;
        GameManager.instance.skillPoints -= 1;
    }
}
