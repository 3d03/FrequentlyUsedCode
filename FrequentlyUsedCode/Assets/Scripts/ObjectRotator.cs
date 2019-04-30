using UnityEngine;
using System.Collections;
 
public class ObjectRotator : MonoBehaviour 
{
 
    private float _sensitivity;
    public Vector3 _mouseReference;
    public Vector3 _mouseOffset;
    public Vector3 _rotation;
    public bool _isRotating;
 
    void Start ()
    {
       _sensitivity = 0.4f;
       _rotation = Vector3.zero;
    }
 
    void Update()
    {
       if(_isRotating)
       {
         // offset
         _mouseOffset = (Input.mousePosition - _mouseReference);
 
         // apply rotation
         //_rotation.x = (_mouseOffset.y) * _sensitivity;
		 _rotation.y = -(_mouseOffset.x) * _sensitivity;
			
 
         // rotate
         transform.Rotate(_rotation);
 
         // store mouse
         _mouseReference = Input.mousePosition;
       }
    }
 
    void OnMouseDown()
    {
       // rotating flag
       _isRotating = true;
 
       // store mouse
       _mouseReference = Input.mousePosition;
    }
 
    void OnMouseUp()
    {
       // rotating flag
       _isRotating = false;
    }
 
}