using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public float price = 1f;

}

public class TradeScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public TradeScrollList otherShop;
    public Text currentGoldText;
    public SimpleObjectPool buttonObjectPool;
    public GameManager gameManager;

	void Start ()
    {
        RefreshDisplay();
	}

    public void RefreshDisplay()
    {
        currentGoldText.text = currentGoldText.ToString();
        RemoveButtons();
        AddButtons();
    }
	
    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ItemButton itemButton = newButton.GetComponent<ItemButton>();
            itemButton.Setup(item, this);
        }
    }

    private void RemoveButtons()
    {
     while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void TryTransferItemToPlayerInventory (Item item)
    {
        if (gameManager.currentGold >= item.price)
        {
            gameManager.currentGold -= item.price;
            AddItem(item, otherShop);
            RemoveItem(item, this);

            RefreshDisplay();
            otherShop.RefreshDisplay();
        }
    }

    private void AddItem(Item itemToAdd, TradeScrollList tradeList)
    {
        tradeList.itemList.Add(itemToAdd);
    }

    private void RemoveItem (Item itemToRemove, TradeScrollList tradeList)
    {
        for (int i = tradeList.itemList.Count - 1; i >=0; i--)
        {
            if (tradeList.itemList[i] == itemToRemove)
            {
                tradeList.itemList.RemoveAt(i);
            }
        }
    }
}
