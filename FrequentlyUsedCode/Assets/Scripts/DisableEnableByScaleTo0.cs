using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableByScaleTo0 : MonoBehaviour {

    public bool scaleToZeroAtStart;
    Vector3 initScale;


	// Use this for initialization
	void Awake () {
        initScale = this.transform.localScale;
	}

    private void Start()
    {
        if (scaleToZeroAtStart)
        {
            ScaleToZero();
        }
    }
    public void ScaleToZero()
    {
        this.transform.localScale = Vector3.zero;
    }


    public void ScaleToInit()
    {
        this.transform.localScale = initScale;
    }
}
