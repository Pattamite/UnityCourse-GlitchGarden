using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{
	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_"; //level_unlocked_1
	const string DIFF_KEY = "difficulty";
	
	public static void SetMasterVolume (float volume)
	{
		if(volume >= 0f && volume <= 1f) PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		else Debug.LogError("Master volume out of range");
	}
	
	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level)
	{
		if(level <= Application.levelCount-1)
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
		}
		else Debug.LogError("Failed to Unlock level " + level);
	}
	
	public static bool IsLevelUnlocked (int level)
	{
		if(level <= Application.levelCount-1)
		{
			int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString(), 1);
			bool isLevelUnlocked = (levelValue == 1);
			return isLevelUnlocked;
		}
		else
		{
			Debug.LogError("Failed to check level " + level);
			return false;
		}
	}
	
	public static void SetDiificulty (float difficulty)
	{
		if(difficulty>=1f && difficulty<=3f) PlayerPrefs.SetFloat(DIFF_KEY, difficulty);
		else Debug.LogError("Difficulty out of range.");
	}
	
	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFF_KEY);
	}
}
