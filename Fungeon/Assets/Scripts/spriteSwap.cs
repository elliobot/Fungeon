using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteSwap : MonoBehaviour
{
    bool state1 = false;
    public Toggle targetObj;
    private Image targetRend;
    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {
        targetRend = targetObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swapSprite()
    {
        if (state1)
        {
            targetObj.image.sprite = sprite1;
            state1 = false;

        }
        else
        {
            targetObj.image.sprite = sprite2;
            state1 = true;

        }
    }
}
