using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;
		//Debug.Log ("Lizard collided with " + collider);
		if(!obj.GetComponent<defender>())
		{
			return;
		}
		else
		{
			anim.SetBool("Attacking", true);
			attacker.Attack(obj);
		}
	}
}
