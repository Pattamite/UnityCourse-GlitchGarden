using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public float autoLoadTime = 0f;

	private static int LastestLevel;
	
	void Start()
	{
		if(autoLoadTime > 0f) 
		{
			Debug.Log ("Enable Autoload");
			Invoke("LoadNextLevel", autoLoadTime);
		}
	}
	
	public void LoadLevel(string name)
	{
		LastestLevel = Application.loadedLevel;
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel()
	{
		LastestLevel = Application.loadedLevel;
		Debug.Log ("Next level load requested for: " + (Application.loadedLevel + 1));
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void LoadLastestLevel()
	{
		int temp = Application.loadedLevel;
		Debug.Log ("Lastest level load requested for: " + (LastestLevel));
		Application.LoadLevel(LastestLevel);
		LastestLevel = temp;
	}
	
	public void QuitRequest()
	{
		Debug.Log ("Quit Requested");
		Application.Quit();
	}
}
