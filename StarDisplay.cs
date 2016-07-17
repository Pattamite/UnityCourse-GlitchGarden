using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	private Text StarText;
	private int star = 100;
	public enum Status {SUCCESS, FAILURE};
	
	// Use this for initialization
	void Start () 
	{
		StarText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars(int value)
	{
		star += value;
		UpdateDisplay();
	}
	
	public Status UseStars(int value)
	{
		if(star >= value)
		{
			star -= value;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		else return Status.FAILURE;
	}
	
	private void UpdateDisplay()
	{
		StarText.text = star.ToString(); 
	}
}
