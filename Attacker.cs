using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour 
{
	public float seenEveryTimePerLane;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget) anim.SetBool("Attacking", false);
	}
	
	void OnTriggerEnter2D()
	{
		//Debug.Log(name + " triggered.");
	}
	
	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget (float damage)
	{
		if(currentTarget)
		{
			Health health = currentTarget.GetComponent<Health>();
			if(health)
			{
				health.DealDamage(damage);
			}
		}
		Debug.Log(name + " caused " + damage + " damage to " + currentTarget);
	}
	
	public void Attack (GameObject obj)
	{
		currentTarget = obj;
		
	}
}
