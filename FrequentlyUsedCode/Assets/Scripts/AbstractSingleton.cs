using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    public static bool InstanceExists => instance != null;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this as T;
        }
        else
        {
            Debug.Log("Duplicate Instance on " + typeof(T).ToString());
        }    

    }


    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    string goName = typeof(T).ToString()+" singleTon_autocreated";
                    Debug.Log(typeof(T).ToString() + " singleTon_autocreated");

                    GameObject go = GameObject.Find(goName);
                    if (go == null)
                    {
                        go = new GameObject();
                        go.name = goName;
                    }

                    instance = go.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
