using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
	
	public IslandType islandType;
	public List<Item> item;
	public 
	ShopItemLists itemList;

	// Use this for initialization
	void Start () {
		itemList = GameObject.Find ("ItemManager").GetComponent<ShopItemLists> ();
		FillList ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void FillList()
	{
		item = new List<Item>();
		foreach(ItemType it in itemList.itemsList)
		{
			if(it.ContainsIslandType(islandType))
			{
				Item i = new Item ();
				i.itemType = it;
				i.amount = Random.Range (i.itemType.minAmount, i.itemType.maxAmount);
				i.price = Random.Range (i.itemType.minPrice, i.itemType.maxPrice);
				item.Add (i);
			}
		}
	}
}



public enum IslandType
{
	Arctic,
	Barrens,
	Forest,
	Grassland,
	Swamp,
	Volcanic,

}