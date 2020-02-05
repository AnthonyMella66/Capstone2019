using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

	private AudioClip audioStream = null;

	// Use this for initialization
	void Start () {

		// First argument is the microphone name, set it to default device in the microhpone settings
		// 
		audioStream = Microphone.Start("Vive", true, 3, 44200);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
