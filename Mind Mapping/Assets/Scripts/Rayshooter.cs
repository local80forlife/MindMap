using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayshooter : MonoBehaviour {
	private Camera _camera;
	public GameObject Note;
	private float cardRotateWest = 90.0f;
	private float cardRotateEast = -90.0f;
	private float cardRotateSouth = -180.0f;

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
				card.transform.position = hit.point;
				//wallRotation = hitWall.transform.rotation;
				//card.transform.rotation.y = wallRotation.y
				if(hit.transform.gameObject == GameObject.Find("WallWest")){
					card.transform.localEulerAngles = new Vector3(0, cardRotateWest, 0);
				}
				if (hit.transform.gameObject == GameObject.Find ("WallEast")) {
					card.transform.localEulerAngles = new Vector3 (0, cardRotateEast, 0);
				}
				if (hit.transform.gameObject == GameObject.Find ("WallSouth")) {
					card.transform.localEulerAngles = new Vector3 (0, cardRotateSouth, 0);
				}

				Debug.Log("Rotation " +  hitWall.transform.rotation);

			}
		}
	}
}
