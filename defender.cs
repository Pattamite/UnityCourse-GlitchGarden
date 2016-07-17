using UnityEngine;
using System.Collections;

public class defender : MonoBehaviour 
{
	private StarDisplay starDisplay;
	public int starCost;
	
	void Start()
	{
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStar (int value)
	{
		starDisplay.AddStars(value);
	} 
	
}
