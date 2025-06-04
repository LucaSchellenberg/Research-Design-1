using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public AudioSource audioSource;

    void OnInteract()
    {
        if (audioSource != null)
            audioSource.Play();
        else
            Debug.Log("No AudioSource assigned on: " + gameObject.name);
    }
}
