using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public ShipController shipController;

	[Header ("Essentials")]
	public float startingGold;
	public float currentGold;

	[Header ("Time and Date")]
	public float hour;
	public float hourSpeed;
	public int day;
	public int month;
	public int year;

	[Header ("UI Elements")]
	public Text gold;
	public Text date;
	public GameObject gamePaused;

	void Start () 
	{
		currentGold = startingGold;
	}

	void Update ()
	{
		if (shipController.moving == false)
		{
			gamePaused.SetActive(true);
		}
		else
		{
			gamePaused.SetActive(false);
		}
		if (shipController.moving == true)
		{
			hour += Time.deltaTime * hourSpeed;

			if (hour >= 23.5f) 
			{
				day++;
				hour = 0;
			}
			if (day == 30) 
			{
				month++;
				day = 1;
			}
			if(month == 12)
			{
				year++;
				month = 1;
			}
		}
		gold.text = currentGold.ToString();
		date.text = day + "." + month + "." + year +  " - " + System.Math.Round(hour,0) + ":00";

	}

  }
