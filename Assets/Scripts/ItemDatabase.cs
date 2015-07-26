using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start ()
	{
		items.Add(new Item(0, "Copper Ore", "A large chunk of copper and rock.", null, Item.ItemType.Craftable, 25));
		items.Add(new Item(1, "Tin Ore", "A large chunk of tin and rock.", null, Item.ItemType.Craftable, 25));
		items.Add(new Item(2, "Iron Ore", "A large chunk of iron and rock.", null, Item.ItemType.Craftable, 25));
	}

}
