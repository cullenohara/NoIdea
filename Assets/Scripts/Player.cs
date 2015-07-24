using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour {

	private Rigidbody playerRB;
	public int speed = 20;
	public InputField input;
	public Text textArea;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody> ();
		input.onEndEdit.AddListener (SubmitMessage);
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
		Debug.Log (arg0);
		textArea.text += arg0 + "\n";
		input.text = "";
	}
}
