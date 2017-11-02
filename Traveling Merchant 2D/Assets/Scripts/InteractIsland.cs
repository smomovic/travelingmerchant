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
	public GameObject shopItemHolderPrefab;
	public Transform shopGrid;
	public Island currentIsland;

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
				FillList ();
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
		currentIsland = other.GetComponent<Island> ();
        tradable = true;
	}

	void OnTriggerExit(Collider other)
	{
		interactIcon.SetActive (false);
        tradable = false;
		trading = false;
	}

	void FillList()
	{
		foreach (Transform t in shopGrid) 
		{
			Destroy (t.gameObject);
		}
		for(int i = 0; i < currentIsland.item.Count; i++)
		{
			GameObject holder = Instantiate (shopItemHolderPrefab, shopGrid);

			ItemHolder holderScript = holder.GetComponent<ItemHolder> ();

			holderScript.itemName.text = currentIsland.item [i].itemType.name;
			holderScript.itemIcon.sprite = currentIsland.item [i].itemType.icon;
			holderScript.itemAmount.text = currentIsland.item [i].amount.ToString("0") + "x";
			holderScript.itemPrice.text = currentIsland.item [i].price.ToString("0") + " Gold";



		}	
	}
}
