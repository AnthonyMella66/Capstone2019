using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class NewBehaviourScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // Device name as listed in the devices panel, might be useful to rename to "Vive"
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("Microhphone", true, 10, 44100);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
