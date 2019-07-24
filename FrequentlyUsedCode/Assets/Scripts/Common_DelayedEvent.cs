using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Common{
	public class Common_DelayedEvent : MonoBehaviour {
		public float delay = 0.5f;
		public UnityEvent eventToInvoke;

        
		public void InvokeEventWithDelay(){
			StartCoroutine(TakeFunction());
        }

		IEnumerator TakeFunction(){
			yield return new WaitForSeconds(delay);
			if (eventToInvoke != null)
                eventToInvoke.Invoke();
		}
	}
}