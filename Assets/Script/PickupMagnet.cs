using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMagnet : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
