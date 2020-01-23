using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    //public AudioSource audioSource = GetComponent<AudioSource>();
    public AudioSource rick;
    // Start is called before the first frame update
    void Start()
    {
        // Device name as listed in the devices panel, might be useful to rename to "Vive"
        rick.clip = Microphone.Start(null, true, 10, 44100);
        rick.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
