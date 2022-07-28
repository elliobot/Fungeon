using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offence : MonoBehaviour
{
    float elapsed = 0;
    System.Random rand = new System.Random();
    float randRoll = 0f;
    public GameObject boosnCheers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {

            boosnCheers.GetComponent<RandomParticle>().enabled = false;

            elapsed = elapsed % 1f;
            for (int i = 1; i <= GameManager.instance.skeletonCount; i++)
            {
                offenceRoll();
            }
            
        }
    }
    public void superheroShirt()
    {
        GameManager.instance.skilloffenceChance += 0.5f;
        GameManager.instance.skillPoints -= 1;
        GameManager.instance.skillTree[6] = true;


    }
    public void offenceRoll()
    {

        randRoll = rand.Next(1, 1000);

        if (randRoll <= (GameManager.instance.offenceChance + GameManager.instance.skilloffenceChance) * 10)
        {
            boosnCheers.GetComponent<RandomParticle>().enabled = true;

            GameManager.instance.offended += 1;
        }
        
    }

}
