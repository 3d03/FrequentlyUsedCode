using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnhancedButton : MonoBehaviour
{
    [Space(20)]
    public bool isEnabled=true;
    [Space(20)]

    public bool simpleClickEnabled;
    public UnityEvent[] simpleClickEvents;
    private int simpleClickCounter;
    
    [Space(20)]
    public bool doubleClickEnabled;
    private int doubleClickCounter;
    public float doubleClickTimeout = 0.2f;
    private bool firstClickEnabled = true;
    private bool doubleClick = false;

    public UnityEvent[] doubleClickEvents;

    [Space(20)]
    bool pointerDown;
    float pointerDownTimer=0f;






    #region buttons interactivity state on/off switch
    public void EnableButton()
    {
        isEnabled = true;
    }

    public void DisableButton()
    {
        isEnabled = false;
    }

    public void SwitchEnableDisableButton()
    {
        isEnabled = !isEnabled;
    }

    public void EnableButtonForTime(float enabledDurability)
    {
        isEnabled = true;
        Invoke("DisableButton", enabledDurability);
    }

    public void DisableButtonForTime(float disabledDurability)
    {
        isEnabled = false;
        Invoke("EnableButton", disabledDurability);
    }
    #endregion

 

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
    
   
    private void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (isEnabled)
            {
                if (doubleClickEnabled)
                {
                    if (firstClickEnabled)
                    {
                        firstClickEnabled = false;
                        StartCoroutine(trapDoubleClicks(doubleClickTimeout));
                    }
                }
            }
        }
    }

    
    void SimpleClick()
    {
        if (simpleClickEnabled)
            if (!EventSystem.current.IsPointerOverGameObject())
            { 
                if (simpleClickEvents[simpleClickCounter] != null)
                {
                    simpleClickEvents[simpleClickCounter].Invoke();
                }
                simpleClickCounter++;
                if (simpleClickCounter == simpleClickEvents.Length)
                {
                    simpleClickCounter = 0;
                }
            }
    }
    void DoubleClick()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        { 
            if (doubleClickEvents[doubleClickCounter] != null)
            {
                doubleClickEvents[doubleClickCounter].Invoke();
            }
            doubleClickCounter++;
            if (doubleClickCounter == doubleClickEvents.Length)
            {
                doubleClickCounter = 0;
            }
        }
    }


    void OnMouseDown()
    {
        if (isEnabled)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                if (doubleClickEnabled)
                {
                
                    {
                        pointerDown = true;
                    }
                }
                else

                {
                    SimpleClick();
                    Debug.Log("SINGLE CLICK WITHOUT DOUBLE CLICK");
                }
        }
    }

   

    
     
 

    IEnumerator trapDoubleClicks(float timer)
    {
        Debug.Log("Starting to listen for double clicks");
        float endTime = Time.time + timer;
        while (Time.time < endTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                yield return new WaitForSeconds(0.4f);
                firstClickEnabled = true;
                doubleClick = true;
                Debug.Log("Double click!");
                DoubleClick();
            }
            yield return 0;
        }

        if (!doubleClick)
        {
            Debug.Log("SINGLE CLICK");
            SimpleClick();
        }
        else
        {
            doubleClick = false;
        }

        firstClickEnabled = true;
        yield return 0;
    }







    #region InvokeEventsByCall

    public void InvokeSimpleClickEvents(int index)
    {
        if (index< simpleClickEvents.Length)
            simpleClickEvents[index].Invoke();
    }

    public void InvokeDoubleClickEvents(int index)
    {
        if (index < doubleClickEvents.Length)
            doubleClickEvents[index].Invoke();
    }

   
    #endregion
}
