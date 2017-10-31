using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class ShopItems
{
    public string itemName;
    public Sprite icon;
    public float price = 1f;
	public float amount = 1f;

}

public class TradeScrollList : MonoBehaviour {

	public List<ShopItems> itemList;
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
            ShopItems item = itemList[i];
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

    public void TryTransferItemToPlayerInventory (ShopItems item)
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

    private void AddItem(ShopItems itemToAdd, TradeScrollList tradeList)
    {
        tradeList.itemList.Add(itemToAdd);
    }

    private void RemoveItem (ShopItems itemToRemove, TradeScrollList tradeList)
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
