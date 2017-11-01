using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
	public string name;	
	public float price;
	public Sprite icon;
	public float amount;
}

public class ShopItemLists : MonoBehaviour {

	public GameObject shopItemHolderPrefab;
	public Transform shopGrid;
	public List<Item> itemsList;
		
	void Start () {

		FillList ();
	}


	public void Update()
	{
	}
	

	public void FillList()
	{
		for(int i = 0; i < itemsList.Count; i++)
		{
			GameObject holder = Instantiate (shopItemHolderPrefab, shopGrid);

			ItemHolder holderScript = holder.GetComponent<ItemHolder> ();

			holderScript.itemName.text = itemsList [i].name;
			holderScript.itemPrice.text = itemsList [i].price.ToString() + " Gold";
			holderScript.itemAmount.text = itemsList [i].amount.ToString() + "x";
			holderScript.itemIcon.sprite = itemsList [i].icon;

		}	
	}
}
