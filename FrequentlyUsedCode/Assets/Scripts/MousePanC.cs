using UnityEngine;
using System.Collections;

public class MousePanC : MonoBehaviour {

	// Use this for initialization

	public float mouseSensitivity=1.0f;
	private Vector3 lastPosition;
	private Vector3 delta;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((Input.GetMouseButtonDown(0))||(Input.GetMouseButtonDown(1))||(Input.GetMouseButtonDown(2)))
		{
			lastPosition = Input.mousePosition;
		}
		
		if ((Input.GetMouseButton(0))||(Input.GetMouseButton(1))||(Input.GetMouseButton(2)))
		{
			delta = Input.mousePosition - lastPosition;
			transform.Translate(delta.x * mouseSensitivity, delta.y * mouseSensitivity, 0);
			lastPosition = Input.mousePosition;
		}
	}
}



