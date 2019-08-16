using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


class A
{
    public virtual void Foo()
    {
        Debug.Log("Class A");
    }
}

class B : A
{
    public override void Foo()
    {
        Debug.Log("Class B");
    }
}


public struct S : IDisposable
{
    private bool dispose;
    public void Dispose()
    {
        dispose = true;
    }
    public bool GetDispose()
    {
        return dispose;
    }
}


public class InheritanceTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        //B obj2 = new B();
        //obj2.Foo();

        //A obj3 = new B();
        //obj3.Foo();





        var s = new S();
        using (s)
        {
          //  Debug.Log(s.GetDispose());
        }
        //Debug.Log(s.GetDispose());






        List<Action> actions = new List<Action>();
        for (var count = 0; count < 10; count++)
        {
            //Debug.Log(count);
            //actions.Add(() => Debug.Log(count));
        }
        foreach (var action in actions)
        {
            action();
        }





        int i = 1;
        object obj = i;
        ++i;
        //Debug.Log(i);
        //Debug.Log(obj);
        //Debug.Log((int)obj);


    }










    // Update is called once per frame
    void Update()
    {
        
    }
}
