using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillTree : MonoBehaviour
{

    public TMP_Text skillpointText;
    public GameObject skillArea;
    public enum OffenceOrClean { Offensive, Nautral, Clean }

    public OffenceOrClean OOC;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt = skillArea.GetComponent(typeof(RectTransform)) as RectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (OOC == OffenceOrClean.Offensive)
        {
            skillpointText.text = "Skill Points: " + GameManager.instance.skillPoints.ToString();
            rt.sizeDelta = new Vector2(0, 483 + (50 * (GameManager.instance.offenceCount)));
        }
        else if (OOC == OffenceOrClean.Clean)
        {
            skillpointText.text = "Skill Points: " + GameManager.instance.skillPoints.ToString();
            rt.sizeDelta = new Vector2(0, 483 + (50 * (GameManager.instance.cleanCount)));
        }
        else
        {

            skillpointText.text = "Skill Points: " + GameManager.instance.skillPoints.ToString();
            rt.sizeDelta = new Vector2(0, 483 + (50 * (GameManager.instance.skillCount)));
        }
    }
}
