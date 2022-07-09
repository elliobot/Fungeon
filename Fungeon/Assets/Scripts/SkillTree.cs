using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillTree : MonoBehaviour
{

    public TMP_Text skillpointText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skillpointText.text = "Skill Points: " + GameManager.instance.skillPoints.ToString();
    }
}
