using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainClick : MonoBehaviour
{
    float elapsed = 0;
    public Button mainClickButton;
    public jokeGenerate jokebox;
    public Offence offenceScript;
    public GameObject player;
    private SpriteRenderer playerSprite;
    public Sprite openMouth;
    public Sprite closedMouth;
// Start is called before the first frame update
    void Start()
    {
       playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.cooldownSlider.maxValue = GameManager.instance.jokeSpeed * 10;

        if (!mainClickButton.interactable)
        {
            playerSprite.sprite = openMouth;
            elapsed += Time.deltaTime;

            GameManager.instance.cooldownSlider.value = (GameManager.instance.jokeSpeed * 10) - (elapsed * 10);
            if (GameManager.instance.cooldownSlider.value == 0)
            {
                elapsed = 0;
                GameManager.instance.cooldownSlider.value = GameManager.instance.jokeSpeed *10;
                GameManager.instance.cooldownSlider.maxValue = GameManager.instance.jokeSpeed *10;
                mainClickButton.interactable = true;
                GameManager.instance.cooldownSlider.gameObject.SetActive(false);
                if (GameManager.instance.autoclickUpgrade == true)
                {
                    buttonPress();
                    jokebox.makeJoke();
                    offenceScript.offenceRoll();
                }
            }
            else
            {
                mainClickButton.interactable = false;

            }

        }
        else
        {
            playerSprite.sprite = closedMouth;

        }
    }

    public void buttonPress()
    {
        GameManager.instance.moneyTotal += 1+ GameManager.instance.clickMult * ((GameManager.instance.skeletonCount) * (GameManager.instance.jokePower * GameManager.instance.jokeMult));
        GameManager.instance.playerXP += 1+GameManager.instance.clickMult * ((GameManager.instance.skeletonCount) * (GameManager.instance.jokePower * GameManager.instance.jokeMult));
        mainClickButton.interactable = false;
        GameManager.instance.cooldownSlider.gameObject.SetActive(true);
    }

}
