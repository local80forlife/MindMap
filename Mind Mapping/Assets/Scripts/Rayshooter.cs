using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayshooter : MonoBehaviour {
	private Camera _camera;
	public GameObject Note;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelWidth / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("Hit " + hit.point); 
				GameObject card = (GameObject)Instantiate (Note);
				card.transform.position = hit.point;


			}
		}
	}
}
