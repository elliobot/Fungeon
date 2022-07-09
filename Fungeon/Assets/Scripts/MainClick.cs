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
// Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.cooldownSlider.maxValue = GameManager.instance.jokeSpeed;

        if (!mainClickButton.interactable)
        {
            elapsed += Time.deltaTime;

            GameManager.instance.cooldownSlider.value = GameManager.instance.jokeSpeed - elapsed;
            if (GameManager.instance.cooldownSlider.value <= 0)
            {
                elapsed = elapsed % GameManager.instance.jokeSpeed;
                GameManager.instance.cooldownSlider.value = GameManager.instance.jokeSpeed;
                GameManager.instance.cooldownSlider.maxValue = GameManager.instance.jokeSpeed;
                mainClickButton.interactable = true;
                GameManager.instance.cooldownSlider.gameObject.SetActive(false);
                if (GameManager.instance.autoclickUpgrade == true)
                {
                    buttonPress();
                    jokebox.makeJoke();
                    offenceScript.offenceRoll();
                }
            }

        }
    }

    public void buttonPress()
    {
        GameManager.instance.moneyTotal += GameManager.instance.clickMult * ((GameManager.instance.skeletonCount) * (GameManager.instance.jokePower * GameManager.instance.jokeMult));
        GameManager.instance.playerXP += ((GameManager.instance.skeletonCount) *  (GameManager.instance.jokePower * GameManager.instance.jokeMult));
        mainClickButton.interactable = false;
        GameManager.instance.cooldownSlider.gameObject.SetActive(true);
    }

}
