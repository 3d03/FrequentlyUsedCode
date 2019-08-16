using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutTestOne : MonoBehaviour
{

    public float f = 0f;
    float fMax = 10f;

    public GameObject moveGO;
    public float moveTime;
    public float moveSpeed;
    public Transform A;
    public Transform B;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RiseF(5));
        //StartCoroutine(RiseFByIncrement(0.1f));
        // StartCoroutine(RiseFByIncrementAtOneSecond(0.1f));

        //StartCoroutine(MoveBySpeed());
        //StartCoroutine(MoveByTime());
        //StartCoroutine(MoveByTimePingPong(false));
        //StartCoroutine(MoveBySpeedPingPong(false));

        StartCoroutine(DebugUntilF_Pressed());
        
    }

    bool FPressed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FPressed = true;
        }
    }
    #region RiseF coroutines
    IEnumerator RiseF(float time)
    {
        float addValue =  (Time.deltaTime  / time)*(fMax-f);

        while (f<fMax)
        {
            f += addValue;
            yield return new WaitForEndOfFrame();
           /// Debug.Log(f);
        }
    }

    IEnumerator RiseFByIncrement(float increment)
    {
        while (f < fMax)
        {
            f += increment;
            yield return new WaitForEndOfFrame();
            //Debug.Log(f);
        }
    }

    IEnumerator RiseFByIncrementAtOneSecond(float increment)
    {
        while (f < fMax)
        {
            f += increment;
            yield return new WaitForSeconds(1);
            Debug.Log(f);
        }
    }
    #endregion


#region Movers Coroutines


    IEnumerator MoveBySpeed()
    {
        float movedDist = 0;

        while (movedDist < Vector3.Distance(A.position, B.position))
        {
            movedDist += moveSpeed * Time.deltaTime;
            moveGO.transform.position = Vector3.Lerp(A.position, B.position, movedDist/ Vector3.Distance(A.position, B.position));
            yield return new WaitForEndOfFrame();
        }
    }


    IEnumerator MoveBySpeedPingPong(bool reverse)
    {
        float movedDist = 0;

        while (movedDist < Vector3.Distance(A.position, B.position))
        {
            movedDist += moveSpeed * Time.deltaTime;
            if (reverse)
                moveGO.transform.position = Vector3.Lerp(B.position, A.position, movedDist / Vector3.Distance(A.position, B.position));
            else
                moveGO.transform.position = Vector3.Lerp(A.position, B.position, movedDist / Vector3.Distance(A.position, B.position));
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(MoveBySpeedPingPong(!reverse));
    }



    IEnumerator MoveByTime()
    {
        float elapsedTime = 0;

        while (elapsedTime <moveTime)
        {
            elapsedTime +=  Time.deltaTime;
            moveGO.transform.position = Vector3.Lerp(A.position, B.position, elapsedTime / moveTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator MoveByTimePingPong(bool reverse)
    {
        float elapsedTime=0;

    
        while (elapsedTime < moveTime)
            {
                elapsedTime += Time.deltaTime;
                if (reverse)
                    moveGO.transform.position = Vector3.Lerp(B.position, A.position, elapsedTime / moveTime); 
                else
                    moveGO.transform.position = Vector3.Lerp(A.position, B.position, elapsedTime / moveTime);
            yield return new WaitForEndOfFrame();
            }

        StartCoroutine(MoveByTimePingPong(!reverse));

    }

    #endregion

    #region SomeEventWaiters

    IEnumerator DebugUntilF_Pressed()
    {

        /*
        int secondCounter = 0;
        do
        {
            Debug.Log("Waiting " + secondCounter + " seconds");
            yield return new WaitForSeconds(1);
            secondCounter++;
        }
        while (FPressed == false);
        */
        do {
            Debug.Log("Waiting F pressed");
            yield return new WaitForEndOfFrame();
        }
        while (FPressed==false);

    


        yield return new WaitUntil(() => FPressed);
        Debug.Log("F pressed");
    }

    #endregion


}
