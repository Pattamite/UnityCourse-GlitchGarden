using UnityEngine;
using System.Collections;

public class DefenderSpwaner : MonoBehaviour 
{
	public Camera myCamera; 
	private GameObject DefenderParent;
	private StarDisplay starDisplay;
	
	void Start()
	{
		DefenderParent = GameObject.Find("Defender");
		if(!DefenderParent)
		{
			DefenderParent = new GameObject("Defender");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	void OnMouseDown()
	{
		if(starDisplay.UseStars(Button.selectedDefender.GetComponent<defender>().starCost) == StarDisplay.Status.SUCCESS)
		{
			GameObject newDefender = Instantiate(Button.selectedDefender, SnapToGrid(CalculateWorldPointOfMouseClick()), Quaternion.identity) as GameObject;
			newDefender.transform.parent = DefenderParent.transform;
		}
		else Debug.Log("Insufficient stars to spawn.");
		
	}
	
	Vector2 CalculateWorldPointOfMouseClick()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 mousePosition = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(mousePosition);
		
		return worldPos;
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		float x = Mathf.RoundToInt(rawWorldPos.x);
		float y = Mathf.RoundToInt(rawWorldPos.y);
		
		return new Vector2 (x,y);
	}
}
