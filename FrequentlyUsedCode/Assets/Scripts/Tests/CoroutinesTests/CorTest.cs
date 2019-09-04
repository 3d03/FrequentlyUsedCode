using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorTest : MonoBehaviour
{

    public Vector3 dir;
    public GameObject mover;
    float speed = 2f;


    void Start()
    {
        StartCoroutine(test());
    }
    IEnumerator test( )
    {
        float movedDist = 0;
        while (movedDist<15f)
        {
            //movedDist += speed * Time.deltaTime;
            //mover.transform.Translate(Vector3.up * speed * Time.deltaTime);
            movedDist += speed * 0.4f;
            mover.transform.Translate(dir * speed * 0.4f);
           // yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(0.4f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
