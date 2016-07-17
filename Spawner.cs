using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject[] attackerPrefabArray;
	
	void Update () 
	{
		foreach (GameObject thisAttacker in attackerPrefabArray)
		{
			if(isTimeToSpawn(thisAttacker))
			{
				Spawn(thisAttacker);
			}
		}
	}
	
	bool isTimeToSpawn(GameObject attackerObject)
	{
		Attacker attacker = attackerObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEveryTimePerLane;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay) Debug.LogWarning ("Spawn rate capped by frame rate");
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		if(Random.value < threshold) return true;
		else return false;
	}
	
	void Spawn (GameObject attacker)
	{
		GameObject newAttacker = Instantiate(attacker, transform.position ,Quaternion.identity) as GameObject;
		newAttacker.transform.parent = transform;
	}
}
