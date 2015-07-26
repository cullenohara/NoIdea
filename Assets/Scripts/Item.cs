using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {

	public int itemID;
	public string itemName;
	public string itemDescription;
	public Sprite itemIcon;
	public ItemType itemType;
	public int itemStack;
	

	public enum ItemType
	{
		Consumable,
		Craftable,
		Weapon,
		Armor
	}

	public Item (int _id, string _name, string _desc, Sprite _icon, ItemType _type, int _stack)
	{
		itemID = _id;
		itemName = _name;
		itemDescription = _desc;
		itemIcon = _icon;
		itemType = _type;
		itemStack = _stack;
	}

}
