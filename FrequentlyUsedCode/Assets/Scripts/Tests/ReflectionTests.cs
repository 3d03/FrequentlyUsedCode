using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;


public class Table
{

    public float height;
    float width;

    public List<GameObject> GOs;
    public void PlaceTable(Vector3 position)
    {

    }

}

delegate string StringOperation(string str);

public class ReflectionTests : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Type mytype = Type.GetType("ReflectionTests");     // также можно использовать   typeof (ReflectionTests);
        

        Debug.Log("mytype.IsAbstract:" + mytype.IsAbstract);
        Debug.Log("mytype.IsInterface:" + mytype.IsInterface);
        Debug.Log("mytype.IsSealed:" + mytype.IsSealed);





        Table table1 = new Table();

        Type tableType = table1.GetType();

        tableType.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public, null, null).ToList().ForEach(s => { Debug.Log(s.ToString()); Debug.Log(s.Name); });


        Type someType = typeof(Table);

        someType.GetFields().ToList().ForEach(t =>
           {
               Debug.Log(t.Name);
               Debug.Log(t.MetadataToken);
           }
        );


        StringOperation stringUpper = delegate (string str)
        {
            return str.ToUpper();
        };

        StringOperation stringLower= delegate (string str)
        {
            return str.ToLower();
        };

        StringOperation stringLowerUpper = delegate (string str)
        {
            string result="";
            for (int i=0; i<str.Length; i++)
            {
                if (i%2==0)
                {
                    result+=str[i].ToString().ToUpper();
                }
                else
                {
                    result += str[i].ToString().ToLower();
                }
            }

            return result;
        };


        


        stringLowerUpper += MultiplyByTwo;

        Debug.Log(stringUpper("awfsdfWEFDSFWEefawef"));
        Debug.Log(stringLower("awfsdfWEFDSFWEefawef"));
        Debug.Log(stringLowerUpper("awfsdfWEFDSFWEefawef"));
    }



    string MultiplyByTwo(string str)
    {
        return str + str;
    }

}
