using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayshooter : MonoBehaviour {
	private Camera _camera;
	public GameObject Note;
	//public float WestWall = 90.0f;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 wallRotation;
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelWidth / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				Debug.Log ("Hit " + hit.point); 
				GameObject hitWall = hit.transform.gameObject;
				Debug.Log ("Object " + hitWall);
				GameObject card = (GameObject)Instantiate (Note);
				//card.transform.position = hit.point;
				//wallRotation = hitWall.transform.rotation;
				//card.transform.rotation.y = wallRotation.y;
				//Debug.Log("Rotation " + wallRotation);

			}
		}
	}
}
