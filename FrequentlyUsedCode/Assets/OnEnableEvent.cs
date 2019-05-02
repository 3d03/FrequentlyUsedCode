using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;


public enum stateEnum { OnEnable,   OnBecameInvisible, OnBecameVisible, Custom}

[System.Serializable]
public class stateAndItsEvents
{
    public float executionDelay;
    [Space(20)]
    public stateEnum state;
    public UnityEvent _event;
    
}

public class OnEnableEvent : MonoBehaviour {

    public List<stateAndItsEvents> _stateAndItsEvents;

    UnityEvent eventToExecute;
    float executionDelay;


    public void CallCustom()
    {
        callEvent(stateEnum.Custom);
    }
    void callEvent(stateEnum _stateEnum)
    {
        if (_stateAndItsEvents.Where(s => s.state == _stateEnum).First() != null)
        {
            eventToExecute = _stateAndItsEvents.Where(s => s.state == _stateEnum).First()._event;
            executionDelay = _stateAndItsEvents.Where(s => s.state == _stateEnum).First().executionDelay;

            if  (executionDelay < 0) 
            {
                executionDelay = 0;
            }
            StartCoroutine("WaitAndExecute");
        }
    }

    void OnEnable () 
	{
        callEvent(stateEnum.OnEnable);
    }

    private void OnBecameVisible()
    {
        callEvent(stateEnum.OnBecameVisible);
    }

   
    private void OnBecameInvisible()
    {
        callEvent(stateEnum.OnBecameInvisible);
    }

 
    


    IEnumerator WaitAndExecute()
    {
      yield return new  WaitForSeconds(executionDelay);
        eventToExecute.Invoke();
    }
}

