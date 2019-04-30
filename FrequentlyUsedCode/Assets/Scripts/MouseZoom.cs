using UnityEngine;
using System.Collections;

public class MouseZoom : MonoBehaviour {
	public Camera mainCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxis("Mouse ScrollWheel")<0)
		{

			if (mainCamera.fieldOfView<=133)
			    {
				mainCamera.fieldOfView+=2;
				}



		}


		if (Input.GetAxis("Mouse ScrollWheel")>0)
		{
			
			if (mainCamera.fieldOfView>=20)
			{
				mainCamera.fieldOfView-=2;
			}
			
			
			
		}


	}
}
