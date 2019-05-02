using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class ButtonCyclic : MonoBehaviour
    {
        //public string genericClickSoundName = "button";
        //public bool useGenerickClickSoundForAll = true;
        public UnityEvent[] clickEvents;
        public string[] clickSoundNames;
        

        private Button button;

        private int clickCounter;
        bool allowed = false;
        

        public void Allow()
            {
            allowed = true;
            }

    public UnityEvent OnEnableEvents;
	void OnEnable () 
	{
        OnEnableEvents.Invoke();
	}

	void OnMouseDown ()
    {
        Debug.Log(("11"));
            //if (allowed)
                if (!EventSystem.current.IsPointerOverGameObject ()) {
			    Click ();
		}
    }

	void OnPointerDown ()
	{
            if (allowed)
                if (!EventSystem.current.IsPointerOverGameObject ()) {
			Click ();
		}
	}

    void Click ()
	{
        Debug.Log(("clicik"));
        if (clickEvents[clickCounter] != null) {
			clickEvents[clickCounter].Invoke ();
		}
        clickCounter++;
        if (clickCounter== clickEvents.Length)
        {
            clickCounter = 0;
        }
	}

	
}

