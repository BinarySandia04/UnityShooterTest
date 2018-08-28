using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (AudioSource))]
public class SoundUIPlayer : MonoBehaviour {
    
    [SerializeField]
    private AudioClip[] audios;

    public void PlayAudioIndex(int index)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.clip = audios[index];
        AS.Play();

        Debug.Log("Emited sound " + index);
    }
	
}
