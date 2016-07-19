using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour 
{
	public float LevelTime = 100f;
	
	private Slider TimeSlider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject loseCollider;
	private GameObject WinText;
	
	// Use this for initialization
	void Start () 
	{
		TimeSlider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		loseCollider = GameObject.Find("Lose Collider");
		WinText = GameObject.Find ("Win Text");
		WinText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		TimeSlider.value =  Time.timeSinceLevelLoad / LevelTime;
		if(Time.timeSinceLevelLoad >= LevelTime && !isEndOfLevel)
		{
			loseCollider.SetActive(false);
			WinText.SetActive(true);
			audioSource.Play();
			Invoke("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}
	
	void LoadNextLevel()
	{
		levelManager.LoadNextLevel();
	}
}
