using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Основано на скрипте ARButton.  Полезно для кнопок типа on/off  или циклического вызова методов, забинденных на одной кнопке
/// </summary>

public class ARButtonCyclic : MonoBehaviour
{
	public SoundManager soundManager;
	public string genericClickSoundName = "button";
    public bool useGenerickClickSoundForAll=true;
	public UnityEvent[] clickEvents;
    public string[] clickSoundNames;

    
    private Animator animator;
	private ShowHideScaler scaler;
	private ShowHideFader fader;

	private Button button;

    private int clickCounter;
    void Start () 
	{
		animator = gameObject.GetComponent<Animator> ();
		scaler = gameObject.GetComponent<ShowHideScaler> ();
		fader = gameObject.GetComponent<ShowHideFader> ();

		button = gameObject.GetComponent<Button>();
		if (button) {
			button.onClick.AddListener (Click);
		}

		Show ();
    }

	void OnEnable () 
	{
		Show ();
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
			if (soundManager) {
                if (useGenerickClickSoundForAll)
                {
                    if (!string.IsNullOrEmpty(genericClickSoundName))
                        soundManager.PlaySound(genericClickSoundName);
                }
                else
                {
                   if (!string.IsNullOrEmpty(clickSoundNames[clickCounter]))
                        soundManager.PlaySound(clickSoundNames[clickCounter]);
                }
			}
		}
        clickCounter++;
        if (clickCounter== clickEvents.Length)
        {
            clickCounter = 0;
        }
	}

	public void Show ()
	{
		if (!this.gameObject.activeSelf) {
			return;
		}

		if (scaler != null) {
			scaler.ScaleUp ();
		}

		if (fader != null) {
			fader.FadelIn ();
		}

		if (animator != null) {
			animator.SetTrigger ("show");
		}
	}

	public void Hide ()
	{
		if (!this.gameObject.activeSelf) {
			return;
		}

		if (scaler != null) {
			scaler.ScaleDown ();
		}

		if (fader != null) {
			fader.FadeOut ();
		}
			
		if (animator != null) {
			animator.SetTrigger ("hide");
		}
	}
}
