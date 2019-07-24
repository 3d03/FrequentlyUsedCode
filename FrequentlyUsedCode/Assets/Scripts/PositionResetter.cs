using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class PositionResetter : MonoBehaviour {


        public List<Transform> transforms;
        public  List<Vector3> initLocalPositions;
        public List<Vector3> initGlobalPositions;

        void Start() {
            CalcInitPositions();
        }

        public void CalcInitPositions()
        {
            initLocalPositions = new List<Vector3>();
            initGlobalPositions = new List<Vector3>();

            for (int i = 0; i < transforms.Count; i++)
            {
                if (transforms[i] != null)
                {
                    initLocalPositions.Add(transforms[i].localPosition);
                    initGlobalPositions.Add(transforms[i].position);
                }
                else
                {
                    Debug.LogWarning("Empty element " + i.ToString() + " in ResetterSctipt transforms list on gameobject" + gameObject.name+". Added Vecto3.zero values");
                    initLocalPositions.Add(Vector3.zero);
                    initGlobalPositions.Add(Vector3.zero);
                }
            }
        }

    //Local positions
    public void Reset_Local_Position(int indexOfTransform)
        {
            transforms[indexOfTransform].localPosition = initLocalPositions[indexOfTransform];
        }

        public void Reset_AllLocal_Position()
        {
            foreach (Transform t in transforms)
            {
                t.localPosition = initLocalPositions[transforms.IndexOf(t)];
            }
        }


        //Global positions
        public void Reset_Global_Position(int indexOfTransform)
        {
            transforms[indexOfTransform].position = initGlobalPositions[indexOfTransform];
        }

        public void Reset_AllGlobal_Position()
        {
            foreach (Transform t in transforms)
            {
                t.position = initGlobalPositions[transforms.IndexOf(t)];
            }
        }
    }
}
