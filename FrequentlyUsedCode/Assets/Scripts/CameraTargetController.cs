using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System.Linq;
[RequireComponent(typeof(LookAtConstraint))]
[RequireComponent(typeof(MouseOrbitImproved))]
public class CameraTargetController : AbstractSingleton<CameraTargetController>
{
    public GameObject targetIndicator;
    public GameObject[] targets;
    int curTargetIndex=0;

    public void ChangeCameraTarget(GameObject ballTarget)
    {
        for (int i=0; i<targets.Length; i++)
        {
            if (targets[i]== ballTarget)
            {
                curTargetIndex = i;
                break;
            }
        }

        SetTarget();
    }

    public void ChangeCameraTarget(int increment)
    {
        curTargetIndex = curTargetIndex + increment ;

        if (curTargetIndex == targets.Length)
        {
            curTargetIndex = 0;
        }
        else
        {
            if (curTargetIndex<0)
            {
                curTargetIndex = targets.Length - 1;
            }
        }


        SetTarget();
    }

    void SetTarget()
    {

        ConstraintSource cs = new ConstraintSource();
        cs.sourceTransform = targets[curTargetIndex].transform;
        cs.weight = 1;
        LookAtConstraint las = gameObject.GetComponent<LookAtConstraint>();
        las.SetSource(0, cs);


        MouseOrbitImproved moi = gameObject.GetComponent<MouseOrbitImproved>();
        moi.target = targets[curTargetIndex].transform;


        targetIndicator.transform.parent = targets[curTargetIndex].transform;
        targetIndicator.transform.localPosition = Vector3.zero;
    }
}
