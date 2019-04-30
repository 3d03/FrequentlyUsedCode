using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum TransformType { Rotation, Movement};
    public TransformType movementType;
    [Space]
    [Header( "Rotation")]

    
    public GameObject ParentHinge;
    public bool NeedToRotate;
    public enum RotDir { Left, Right}
    public RotDir rotDir;
    public float AngleToRot;
    public bool IsClosed;
    public float TimeToRotate;

    [Space]
    [Header("Movement")]
    public GameObject GO_ToMove;
    public bool NeedToMove;
    public float DistanceToMove;

    public Vector3 PositionToMove;

    //public enum MoveAxis { xPlus,xMinus, yPlus, yMinus, zPlus, zMinus };
    //public MoveAxis moveAxis;






    public float TimeToMove;

    Vector3 InitialRot;
    float rotated;

    Vector3 InitialPos;
    float movedDistance;
    Vector3 moveDirection;
    Vector3 ReverseMoveDirection;
    public GameObject FreezedKryska;
    public Vector3 ResetPositionGo_ToMove;
    Vector3 PointPosToRotateAround;
    void Start()
    {

        
        PointPosToRotateAround = this.gameObject.transform.position - (this.gameObject.GetComponent<Renderer>().bounds.size) / 2f;

        /*
        InitialPos = GO_ToMove.transform.position;
        DistanceToMove = Vector3.Distance(ResetPositionGo_ToMove, PositionToMove);

        ReseKryshkaToInitialState();
        */

    }
    
 

        public void OnMouseDown()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            OnTouchMouseDown();
        }
    }



    public void ReseKryshkaToInitialState()
    {

        GO_ToMove.transform.position = FreezedKryska.transform.position;// ResetPositionGo_ToMove;
        //rotated = 0;
        movedDistance = 0;
        IsClosed = true;
        //if (moveAxis==MoveAxis.yMinus)
        //{
        //    moveAxis = MoveAxis.yPlus;
        //}

        //if (moveAxis == MoveAxis.xMinus)
        //{
        //    moveAxis = MoveAxis.xPlus;
        //}



    }


    public void OnTouchMouseDown()

    {


        


        if (movementType == TransformType.Rotation)
        {
            if (ParentHinge != null)
                InitialRot = ParentHinge.transform.localEulerAngles;
            else
                InitialRot = this.transform.localEulerAngles;
            NeedToRotate = true;
        }
        else

       if (movementType == TransformType.Movement)
        {



            moveDirection = PositionToMove;
            ReverseMoveDirection = -PositionToMove;

           
            NeedToMove = true;
        }

    }


    public void Update()
    {
        if (NeedToRotate)
        {
            if (IsClosed)
            {
                if (ParentHinge != null)
                {
                    if (rotDir == RotDir.Left)
                        ParentHinge.transform.Rotate(0, (Time.deltaTime / TimeToRotate) * AngleToRot, 0);
                    else
                      if (rotDir == RotDir.Right)
                        ParentHinge.transform.Rotate(0, -(Time.deltaTime / TimeToRotate) * AngleToRot, 0);

                    rotated = rotated + (Time.deltaTime / TimeToRotate) * AngleToRot;
                }
                
                else
                {

                    

                    if (rotDir == RotDir.Left)
                        this.gameObject.transform.RotateAround(PointPosToRotateAround, Vector3.up,   (Time.deltaTime / TimeToRotate) * AngleToRot);
                    else
                  if (rotDir == RotDir.Right)
                        this.gameObject.transform.RotateAround(PointPosToRotateAround, Vector3.up, -(Time.deltaTime / TimeToRotate) * AngleToRot);

                    rotated = rotated + (Time.deltaTime / TimeToRotate) * AngleToRot;

                }

            }
            else
            {
                if (ParentHinge != null)
                {
                    if (rotDir == RotDir.Left)
                        ParentHinge.transform.Rotate(0, -(Time.deltaTime / TimeToRotate) * AngleToRot, 0);
                    else
                      if (rotDir == RotDir.Right)
                        ParentHinge.transform.Rotate(0, (Time.deltaTime / TimeToRotate) * AngleToRot, 0);


                    rotated = rotated + (Time.deltaTime / TimeToRotate) * AngleToRot;
                }
                else
                {

                    

                        if (rotDir == RotDir.Left)
                            this.gameObject.transform.RotateAround(PointPosToRotateAround, Vector3.up, -(Time.deltaTime / TimeToRotate) * AngleToRot);
                        else
                      if (rotDir == RotDir.Right)
                            this.gameObject.transform.RotateAround(PointPosToRotateAround, Vector3.up, (Time.deltaTime / TimeToRotate) * AngleToRot);

                        rotated = rotated + (Time.deltaTime / TimeToRotate) * AngleToRot;

                    
                }
            }

            if (rotated>=AngleToRot)
            {
                NeedToRotate = false;
                IsClosed = !IsClosed;
                rotated = 0;
            }
        }



        if (NeedToMove)
        {

            

            if (IsClosed)
            {
                GO_ToMove.transform.Translate((Time.deltaTime / TimeToMove) * moveDirection);
                movedDistance = movedDistance + (Time.deltaTime / TimeToMove) * DistanceToMove;
            }
            else
            {
                GO_ToMove.transform.Translate((Time.deltaTime / TimeToMove) * ReverseMoveDirection);
                movedDistance = movedDistance + (Time.deltaTime / TimeToMove) * DistanceToMove;
            }


            if (movedDistance >= DistanceToMove)
            {
                NeedToMove = false;
                IsClosed = !IsClosed;
                movedDistance = 0;
            }
        }

    }





}
