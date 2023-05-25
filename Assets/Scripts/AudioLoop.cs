using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioLoop : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioFile;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(audioFile);
        audioSource.PlayScheduled(AudioSettings.dspTime + audioFile.length);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
