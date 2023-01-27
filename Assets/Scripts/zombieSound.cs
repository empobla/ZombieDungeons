/*
Controls the sound of the zombies
Author Isaac and Jorge 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSound : MonoBehaviour
{
    private float timer = 0f;
    AudioSource audioSource;
    public AudioClip audioZ;
    public int range;
    System.Random random;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        random = new System.Random();
        range= random.Next(0,200);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (range < timer )
        {
            audioSource.PlayOneShot(audioZ, 2f);
            timer = 0;
        }
    }
}
