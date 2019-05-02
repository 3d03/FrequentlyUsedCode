using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {


    [System.Serializable]
    public class DelayEventPair {
        public string Name;
        public float delay;
        public UnityEvent _event;
        [HideInInspector]
        public bool needCancelCurrentComand = false;
    }

    public DelayEventPair[] delayEventPairs;

    int indexOfEventToExecute;
    

    public void InvokeEventWithDelaye(int indexOfEvent)
    {
        delayEventPairs[indexOfEvent].needCancelCurrentComand = false;
        indexOfEventToExecute = indexOfEvent;
        Invoke("ExecuteEvent", delayEventPairs[indexOfEvent].delay);

    }
	
	
	void ExecuteEvent () {
        if (delayEventPairs[indexOfEventToExecute].needCancelCurrentComand == false)
        {
            delayEventPairs[indexOfEventToExecute]._event.Invoke();
        }
    }


    public void CancelCurrentCommand(int indexOfEvent)
    {
        delayEventPairs[indexOfEvent].needCancelCurrentComand = true;
    }
}
