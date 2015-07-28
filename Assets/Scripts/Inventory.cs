using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	public List<Slot> slots = new List<Slot>();
	public int emptySlots;
	public GameObject inventory;
	public Color invColor;
	private Player player;

	void Start ()
	{
		inventory = GameObject.FindGameObjectWithTag("Inventory");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		foreach(Slot slot in inventory.GetComponentsInChildren<Slot>())
		{
			slots.Add(slot);
			emptySlots++;
		}
	}

	public void AddItem(Item item)
	{
		if(CheckForItem(item) == true)
		{
			foreach(Slot slot in slots)
			{
				if(slot.isEmpty == false)
				{
					if(slot.slotItem.Peek().itemID == item.itemID && slot.isFull == false)
					{
						slot.AddToStack(item);
						player.ReceiveMessage("[BACKPACK]", "You found " + item.itemName, "DAE610");
						break;
					}
				}
			}
		}
		else
		{
			FindEmpty(item);
		}
	}

	bool CheckForItem (Item item)
	{
		foreach(Slot slot in slots)
		{
			if(slot.isEmpty == false)
			{
				if(slot.slotItem.Peek().itemID == item.itemID && slot.isFull == false)
				{
					return true;
				}
			}
		}

		return false;
	}

	public void FindEmpty(Item item)
	{
		if(emptySlots > 0)
		{
			foreach(Slot slot in slots)
			{
				if(slot.isEmpty == true)
				{
					slot.AddToStack(item);
					player.ReceiveMessage("[BACKPACK]", "You found " + item.itemName, "DAE610");
					emptySlots--;
					break;
				}
			}
		}
		else
		{
			Debug.Log("Inventory is full.");
		}
	}

	public void RemoveItem(Item item)
	{

	}
}
