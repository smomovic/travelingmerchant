using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIsland : MonoBehaviour {

	public GameObject interactIcon;
    public GameObject playerInventory;
    public GameObject islandInventory;
	public ShopItemLists shopItemList;
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
				shipController.speed = 0;
				Debug.Log ("Trading!");
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
			if(islandInventory.activeSelf)
			{
            islandInventory.SetActive(false);
            playerInventory.SetActive(false);
            shipController.tradeScreen = false;
			}
        }
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			trading = false;
			shipController.speed = 25;
			Debug.Log ("Not Trading Anymore!");
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
		trading = false;
	}
}
