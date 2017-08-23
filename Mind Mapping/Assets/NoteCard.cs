using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCard : MonoBehaviour {
	public Text cardText;
	private Transform cameraPosition;
	private bool active = false;
	private Vector3 oldPosition;
	// Use this for initialization

	void Start () {
		cameraPosition = Camera.main.gameObject.transform;
		Debug.Log ("Start");
	}

	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)) {
			if (!active) {
				oldPosition = gameObject.transform.position;
				Vector3 newPosition = new Vector3 (cameraPosition.position.x, 
					cameraPosition.position.y, 
					cameraPosition.position.z + 1.5f);
				gameObject.transform.position = newPosition;
				Debug.Log ("Did work");
				active = true;
			} else {
				gameObject.transform.position = oldPosition;
				Debug.Log ("Did work");
				active = false;
			}
		}
		Debug.Log ("OnMouseDown");
	}

	// Update is called once per frame
	void Update () {
		if(!active){
			return;
		}
		foreach (char c in Input.inputString) {
			if (c == "\b" [0]) {
				if (cardText.text.Length != 0) {
					cardText.text = cardText.text.Substring (0, cardText.text.Length - 1);
				}
			} else {
				cardText.text += c;
			}

		}

	}
}