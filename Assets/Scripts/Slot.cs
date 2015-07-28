using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

	public RectTransform slotIcon;
	public Text slotText;
	public int slotStack;
	public bool isEmpty = true;
	public bool isFull = false;
	public Stack<Item> slotItem = new Stack<Item>();

	private Vector2 mousePosition;

	public void AddToStack(Item item)
	{
		slotItem.Push(item);
		slotIcon.GetComponent<Image>().sprite = item.itemIcon;
		slotStack++;
		slotText.text = slotStack.ToString();
		isEmpty = false;
		CheckSlotStatus();
	}

	public void RemoveFromStack(Item item)
	{
		slotItem.Pop();
		slotStack--;
		CheckSlotStatus();
	}

	void CheckSlotStatus()
	{
		if(slotStack == 0)
		{
			isEmpty = true;
			slotIcon.GetComponent<Image>().sprite = null;
			slotText.text = string.Empty;
		}
		if(slotStack == slotItem.Peek().itemStack)
		{
			isFull = true;
		}
	}

	void Update ()
	{
		mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}
}
