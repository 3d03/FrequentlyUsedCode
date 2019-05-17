using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    private Transform thisTransform=null;
    public float RotSpeed = 90f;
    public Transform Target = null;
    void Start()
    {
        thisTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion DestRot = Quaternion.LookRotation(Target.position - thisTransform.position, Vector3.up);
        thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, DestRot, RotSpeed * Time.deltaTime);
    }
}
