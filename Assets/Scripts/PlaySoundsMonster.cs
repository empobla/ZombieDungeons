using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundsMonster : MonoBehaviour
{
    Animator animator;
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        audioSource.PlayOneShot(impact, 0.7F);
    }
}
