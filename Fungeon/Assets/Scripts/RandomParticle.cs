using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem laugh1;
    public ParticleSystem laugh2;
    public ParticleSystem laugh3;
    public ParticleSystem laugh4;
    public Sprite haha1;
    public Sprite haha2;
    public GameObject spritenpc;
    private SpriteRenderer spriteRend;
    float elapsed = 0;
    System.Random rand = new System.Random();
    int choice = 0;

    void Start()
    {
        spriteRend = spritenpc.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
        elapsed += Time.deltaTime;

        if (elapsed >= 1f)
        {
            choice = rand.Next(0, 4);
            elapsed = elapsed % 1f;
            if (choice == 0)
            {
                spriteRend.sprite = haha2;

                laugh1.Play();
                laugh2.Stop();
                laugh3.Stop();
                laugh4.Stop();
            }
            else if (choice == 1)
            {
                spriteRend.sprite = haha2;

                laugh1.Stop();
                laugh2.Play();
                laugh3.Stop();
                laugh4.Stop();
            }
            else if (choice == 2)
            {
                spriteRend.sprite = haha1;

                laugh1.Stop();
                laugh2.Stop();
                laugh3.Play();
                laugh4.Stop();
            }
            else if (choice == 3)
            {
                spriteRend.sprite = haha1;

                laugh1.Stop();
                laugh2.Stop();
                laugh3.Stop();
                laugh4.Play();
            }
        }
        
    }
}
