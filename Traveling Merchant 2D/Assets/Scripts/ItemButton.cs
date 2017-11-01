using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Text priceLabel;
	public Text amountLabel;
    public Image iconImage;

    private ShopItems item;
    private TradeScrollList scrollList;

    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(ShopItems currentItem, TradeScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        priceLabel.text = item.price.ToString();
        iconImage.sprite = item.icon;
		amountLabel.text = item.amount.ToString();

        scrollList = currentScrollList;

    }

    public void HandleClick()
    {
        scrollList.TryTransferItemToPlayerInventory(item);
    }
}