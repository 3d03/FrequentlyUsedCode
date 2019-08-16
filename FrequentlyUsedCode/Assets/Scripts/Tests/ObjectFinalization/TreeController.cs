using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
 
namespace ObjectFinalization {
public class Tree: TreeController
    {
    public Tree()
    {
    Debug.Log("Created");
    }

    ~Tree()
    {

        Debug.Log("When ready to be deleted "+ nameof (TreeController.tree2));
    }
 
}

public class TreeController : MonoBehaviour
{

    internal static Tree tree;
    internal static Tree tree2;

    void Start()
    {

         tree = new Tree();
         tree2 = new Tree();
        tree2 = null;
    }
    

    public void ManualDeleteTree()
    {
        tree = null;


    }

}
}