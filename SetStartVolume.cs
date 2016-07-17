using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;
	void Start () 
	{
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager)
		{
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume(volume);
		}
		else Debug.LogWarning("MusicManager not found!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
