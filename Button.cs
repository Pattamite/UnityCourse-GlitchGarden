using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour 
{
	public GameObject defenderPrefabs;
	public static GameObject selectedDefender;
	
	private Button[] buttonArray;
	private Text CostText;

	// Use this for initialization
	void Start () 
	{
		buttonArray  = GameObject.FindObjectsOfType<Button>();
		CostText= GetComponentInChildren<Text>();
		CostText.text = defenderPrefabs.GetComponent<defender>().starCost.ToString();
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
