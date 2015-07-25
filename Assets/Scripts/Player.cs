using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class Player : MonoBehaviour {

	private Rigidbody playerRB;
	public int speed = 20;
	public InputField input;
	public Text textArea;

	private List<string> messages = new List<string>();
	public int maxMessages = 30;

	private string playerName = "Cullen";
	public Color textColor;

	public string GetName
	{
		get { return playerName; }
	}

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody> ();
		input.onEndEdit.AddListener (SubmitMessage);
		input.characterLimit = 144;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement ()
	{
		if (!input.isFocused) {
			if (Input.GetKey (KeyCode.A)) {
				playerRB.AddForce (Vector3.left * speed);
			}
			if (Input.GetKey (KeyCode.D)) {
				playerRB.AddForce (-Vector3.left * speed);
			}
			if (Input.GetKey (KeyCode.W)) {
				playerRB.AddForce (Vector3.forward * speed);
			}
			if (Input.GetKey (KeyCode.S)) {
				playerRB.AddForce (-Vector3.forward * speed);
			}
		}
	}

	private void SubmitMessage(string arg0)
	{
		if(arg0 != "")
		{
			string tempString = "\n" + "<color=#" + textColor.ToHexStringRGB() + "><b>" + playerName + ":</b> " + arg0 + "</color>";
			if(maxMessages > messages.Count)
			{
				messages.Add(tempString);
			}
			else
			{
				messages.RemoveAt(0);
				messages.Add(tempString);
			}

			input.text = "";
			LoadMessages();
		}
	}

	public void ReceiveMessage(string name, string message, string color)
	{
		string tempString = "\n" + "<color=#" + color + "><b>" + name + ":</b> " + message + "</color>";
		if(maxMessages > messages.Count)
		{
			messages.Add(tempString);
		}
		else
		{
			messages.RemoveAt(0);
			messages.Add(tempString);
		}

		LoadMessages();
	}

	private void LoadMessages()
	{
		textArea.text = "";
		foreach(string msg in messages)
		{
			textArea.text += msg;
		}
	}
}
