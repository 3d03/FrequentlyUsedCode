using System.Collections;
using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

public class StringToFieldTest : MonoBehaviour {


    public GameObject Table1;
    public GameObject Table2;
    public GameObject Table3;

    // Use this for initialization
    void Start () {
        for (int i = 1; i < 4; i++)
        {
            Debug.Log(GetAttribute<GameObject>("Table"+i).name);
        }
    }

    public T GetAttribute<T>(string _name)
    {
        return (T)GetType().GetField(_name).GetValue(this);
    }
    
}
