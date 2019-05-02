using UnityEngine;
using System.Collections;

public class MouseZoom : MonoBehaviour {
	
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel")<0)
		{
			if (Camera.main.fieldOfView<=133)
			    {
                Camera.main.fieldOfView+=2;
				}
		}


		if (Input.GetAxis("Mouse ScrollWheel")>0)
		{
			if (Camera.main.fieldOfView>=20)
			{
                Camera.main.fieldOfView-=2;
			}
		}
	}
}
