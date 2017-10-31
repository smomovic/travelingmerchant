using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class GameManager : MonoBehaviour {

	public ShipController shipController;
	public InteractIsland interactisland;
	public GameObject gamePaused;
	public GameObject playerInventory;
	public GameObject mainCamera;

	[Header ("Essentials")]
	public float startingGold;
	public float currentGold;
	public string shipNameText;
	public string captainNameText;

	[Header ("Time and Date")]
	public float hour;
	public float hourSpeed;
	public int day;
	public int month;
	public int year;

	[Header ("UI Elements")]
	public Text gold;
	public Text date;
	public Button itemButton;
	public Toggle cameraFollow;
	public Image shipCaptainPortrait;
	public Text shipMovementSpeed;
	public Text shipCaptainName;
	public Text shipName;

	void Start () 
	{
		currentGold = startingGold;
		cameraFollow.isOn = false;
	}

	void Update ()
	{
		if (cameraFollow.isOn == true) {
			mainCamera.GetComponent<Camera2DFollow> ().enabled = true;
			mainCamera.GetComponent<CameraMovementWithKeys> ().enabled = false;
		}
		else 
		{
			mainCamera.GetComponent<Camera2DFollow> ().enabled = false;
			mainCamera.GetComponent<CameraMovementWithKeys> ().enabled = true;
		}
		if (Input.GetKey(KeyCode.I))
		{
			playerInventory.SetActive(true);
		}

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
		gold.text = currentGold.ToString() +"g";
		shipName.text = shipNameText;
		shipCaptainName.text = captainNameText;
		shipMovementSpeed.text = shipController.speed.ToString () + " km/h";
		date.text = day + "." + month + "." + year +  " - " + System.Math.Round(hour,0) + ":00";

	}

  }
