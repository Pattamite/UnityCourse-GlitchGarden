using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour 
{
	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () 
	{
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		//Debug.Log(musicManager);
	}
	
	// Update is called once per frame
	void Update () 
	{
		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDiificulty(difficultySlider.value);
		levelManager.LoadLevel("01a Menu");
	}
	
	public void SetDefaults()
	{
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
}
