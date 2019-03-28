using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button ))]
public class EscListener : MonoBehaviour {

    public bool isAppCloser;
    public void CloseApp()
    {
        if (isAppCloser)
        {
            Application.Quit();
        }

    }
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isAppCloser)
            {
                Application.Quit();
            }
            else
            { 
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
	}
}
