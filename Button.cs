using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
	public GameObject defenderPrefabs;
	
	private Button[] buttonArray;
	public static GameObject selectedDefender;

	// Use this for initialization
	void Start () 
	{
		buttonArray  = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnMouseDown()
	{
		Debug.Log(name + " pressed");
		
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefabs;
		print (selectedDefender);
	}
}
