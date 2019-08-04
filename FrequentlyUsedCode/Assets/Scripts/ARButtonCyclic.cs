using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ARButtonCyclic : MonoBehaviour
{
	public string genericClickSoundName = "button";
    public bool useGenerickClickSoundForAll=true;
	public UnityEvent[] clickEvents;
    public string[] clickSoundNames;

    
	private Button button;

    private int clickCounter;
    void Start () 
	{
		button = gameObject.GetComponent<Button>();
		if (button) {
			button.onClick.AddListener (Click);
		}
    }


	void OnMouseDown ()
    {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			Click ();
		}
    }

    void OnPointerDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Click();
        }
    }

    public void Click ()
	{
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
