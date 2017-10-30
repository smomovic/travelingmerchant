using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIsland : MonoBehaviour {

	public GameObject interactIcon;
    public GameObject playerInventory;
    public GameObject islandInventory;
    public bool tradable;
    public ShipController shipController;
    public bool trading;

	void Start () {
	}

	void Update () {

        if (tradable == true)
        { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
                trading = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                trading = false;
            }
        }
        if (trading == true)
        {
            islandInventory.SetActive(true);
            playerInventory.SetActive(true);
            shipController.tradeScreen = true;
        }
        if (trading == false)
        {
            islandInventory.SetActive(false);
            playerInventory.SetActive(false);
            shipController.tradeScreen = false;
        }

    }

	void OnTriggerEnter(Collider other)
	{
		interactIcon.SetActive(true);
        tradable = true;
	}

	void OnTriggerExit(Collider other)
	{
		interactIcon.SetActive (false);
        tradable = false;
	}
}
