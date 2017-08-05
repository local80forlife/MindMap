using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour {
	public enum RotationAxes
	{
		MouseXAndY = 0, //player picks the axis to rotate on
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY; //sets rotation axis default 

	public float sensitivityHor = 9.0f; //rotation sensitivity
	public float sensitivityVert = 9.0f; //rotation sensitvity

	public float minimumVert = -45.0f; //minimum degree we can look down
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody> (); //freezes player to rotation set by mouse
		if (body != null)
			body.freezeRotation = true;
	}

	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			//Horizontal Rotation 
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); //GetAxis gets the mouse input
		} else if (axes == RotationAxes.MouseY) {
			//Vertical Rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert); // Clamps the vertical look to a natural angle

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		} else {
			//Horizontal and Vertical Rotation 
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis ("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}

	}

}

