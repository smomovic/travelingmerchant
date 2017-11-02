using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemType
{
	public string name;	
	public Sprite icon;
	public IslandType[] islandType;
	public float minPrice;
	public float maxPrice;
	public float minAmount;
	public float maxAmount;

	public bool ContainsIslandType(IslandType otherType)
	{
		foreach(IslandType itype in islandType)
		{
			if (itype == otherType)
			{
				return true;
			}
		}
		return false;
	}
}

[System.Serializable]
public class Item
{
	public ItemType itemType;
	public float amount;
	public float price;
}

public class ShopItemLists : MonoBehaviour {

	public GameObject shopItemButton;
	public GameObject shopItemHolderPrefab;
	public Transform shopGrid;
	public List<ItemType> itemsList;

	void Start () {

	}


	public void Update()
	{
		
	}
	


}
