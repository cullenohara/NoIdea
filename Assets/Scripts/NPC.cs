using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC : MonoBehaviour {

	public string npcName;
	public List<string> greeting = new List<string>();
	public List<string> farewell = new List<string>();
	public Color textColor;

	// Use this for initialization
	void Start () {
		greeting.Add("Hello");
		greeting.Add("Hi");
		greeting.Add("Good day");

		farewell.Add("Goodbye!");
		farewell.Add("See you soon.");
		farewell.Add("Fuck off!");
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			string tempMessage = greeting[Random.Range(0, greeting.Count)] + " " + other.GetComponent<Player>().GetName;
			other.GetComponent<Player>().ReceiveMessage(npcName, tempMessage, textColor.ToHexStringRGB());
			Item tempItem = new Item(0, "Gold", "Gold coin", Resources.Load<Sprite>("Gold"), Item.ItemType.Consumable, 5);
			other.GetComponent<Inventory>().AddItem(tempItem);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			string tempMessage = farewell[Random.Range(0, farewell.Count)];
			other.GetComponent<Player>().ReceiveMessage(npcName, tempMessage, textColor.ToHexStringRGB());
		}
	}
}
