// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class SmoothCameraOrbitCsharp : MonoBehaviour {
	public Transform TargetLookAt;
	
	public float Distance = 5.0f;
	public float DistanceMin = 3.0f;
	public float DistanceMax = 10.0f;  
	private float mouseX = 0.0f;
	private float mouseY = 0.0f;
	private float startingDistance = 0.0f; 
	private float desiredDistance = 0.0f;  
	public float X_MouseSensitivity = 5.0f;
	public float Y_MouseSensitivity = 5.0f;
	public float MouseWheelSensitivity = 5.0f;
	public float Y_MinLimit = -40.0f;
	public float Y_MaxLimit = 80.0f;   
	public float DistanceSmooth = 0.2f;   
	private float velocityDistance = 0.0f; 
	private Vector3 desiredPosition = Vector3.zero;   
	public float X_Smooth = 0.2f;
	public float Y_Smooth = 0.2f;
	private float velX = 0.0f;
	private float velY = 0.0f;
	private float velZ = 0.0f;
	private Vector3 position = Vector3.zero;  
	
	
	void  Start (){
		Distance = Mathf.Clamp(Distance, DistanceMin, DistanceMax);
		startingDistance = Distance;
		Reset();
	}
	
	void  LateUpdate (){
		if (TargetLookAt == null)
			return;
		
		HandlePlayerInput();
		
		CalculateDesiredPosition();
		
		UpdatePosition();
	}
	
	public void  HandlePlayerInput (){
		float deadZone= 0.01f; // mousewheel deadZone
		
		if (Input.GetMouseButton(0)||Input.GetMouseButton(1))
		{
			mouseX += Input.GetAxis("Mouse X") * X_MouseSensitivity;
			mouseY -= Input.GetAxis("Mouse Y") * Y_MouseSensitivity;
		}
		
		// this is where the mouseY is limited - Helper script
		mouseY = ClampAngle(mouseY, Y_MinLimit, Y_MaxLimit);
		
		// get Mouse Wheel Input
		if (Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
		{
			desiredDistance = Mathf.Clamp(Distance - (Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensitivity), 
			                              DistanceMin, DistanceMax);
		}
	}
	
	public void  CalculateDesiredPosition (){
		// Evaluate distance
		Distance = Mathf.SmoothDamp(Distance, desiredDistance,ref velocityDistance, DistanceSmooth);
		
		// Calculate desired position -> Note : mouse inputs reversed to align to WorldSpace Axis
		desiredPosition = CalculatePosition(mouseY, mouseX, Distance);
	}
	
	public Vector3  CalculatePosition ( float rotationX ,   float rotationY ,   float distance  ){
		Vector3 direction = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
		return TargetLookAt.position + (rotation * direction);
	}
	
	public void  UpdatePosition (){
		float posX= Mathf.SmoothDamp(position.x, desiredPosition.x,ref velX, X_Smooth);
		float posY= Mathf.SmoothDamp(position.y, desiredPosition.y,ref  velY, Y_Smooth);
		float posZ= Mathf.SmoothDamp(position.z, desiredPosition.z,ref velZ, X_Smooth);
		position = new Vector3(posX, posY, posZ);
		
		transform.position = position;
		
		transform.LookAt(TargetLookAt);
	}
	
	public void  Reset (){
		mouseX = 0;
		mouseY = 10;
		Distance = startingDistance;
		desiredDistance = Distance;
	}
	
	public float  ClampAngle ( float angle ,   float min ,   float max  ){
		while (angle < -360 || angle > 360)
		{
			if (angle < -360)
				angle += 360;
			if (angle > 360)
				angle -= 360;
		}
		
		return Mathf.Clamp(angle, min, max);
	}
}