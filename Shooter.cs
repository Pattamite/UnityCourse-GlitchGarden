using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour 
{
	public GameObject projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start()
	{
		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
		Debug.Log(myLaneSpawner);
	}
	
	void Update()
	{
		if(IsAttackerAheadInLane())
		{
			animator.SetBool("Attacking", true);
		}
		else
		{
			animator.SetBool("Attacking", false);
		}
	}
	
	bool IsAttackerAheadInLane()
	{
		if(myLaneSpawner.transform.childCount <= 0 ) return false;
		else
		{
			foreach(Transform child in myLaneSpawner.transform)
			{
				if(child.transform.position.x<10 && child.transform.position.x>transform.position.x) return true;
			}
			return false;
		}
	}
	
	void SetMyLaneSpawner()
	{
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner spawner in spawnerArray)
		{
			if(spawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + "can't find spawner in lane");
	}
	
	private void Fire()
	{
		
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
