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
			transform.Rotate(0, sensitivityHor, 0);
		} else if (axes == RotationAxes.MouseY) {
			//Vertical Rotation
		} else {
			//Horizontal and Vertical Rotation 
		}

	}

}

