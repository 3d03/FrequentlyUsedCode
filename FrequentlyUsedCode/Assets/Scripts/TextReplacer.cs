using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Common
{
    public class TextReplacer : MonoBehaviour
    {

        public string oldStringIndex;
        public string NewString;
        
   

        private void Update()
        {

           
            if (gameObject.GetComponent<TextMeshPro>() != null)
                gameObject.GetComponentInChildren<TextMeshPro>(true).text = gameObject.GetComponentInChildren<TextMeshPro>(true).text.Replace(TextManager.Instance.GetText(oldStringIndex), NewString);

        }
    }
}




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//namespace Common { 
//public class TextReplacer : MonoBehaviour {

//    public string oldStringIndex;
//    public string NewString;
//        bool textIsInitialized=false;
//        bool callOnStart ;
//        string stringAtStart;
//        // Use this for initialization
//        void Start () {
//            textIsInitialized = true;

//            if (callOnStart)
//            {
//                Invoke("ReplaceTextAtStart",1 );
//            }
//        }

//	public void ReplaceText(string newString)
//    {
//            if (textIsInitialized) { 
//                if (gameObject.GetComponent<Text>()!=null)
//                gameObject.GetComponentInChildren<Text>(true).text=gameObject.GetComponent<Text>().text.Replace(TextManager.Instance.GetText(oldStringIndex), newString);

//        if (gameObject.GetComponent<TextMeshPro>() != null)
//                gameObject.GetComponentInChildren<TextMeshPro>(true).text=gameObject.GetComponent<TextMeshPro>().text.Replace(TextManager.Instance.GetText(oldStringIndex), newString);
//            }
//            else
//            {
//                callOnStart = true;
//                stringAtStart = newString;

//            }
//        }

//        void ReplaceTextAtStart()
//        {

//                if (gameObject.GetComponent<Text>() != null)
//                gameObject.GetComponentInChildren<Text>(true).text = gameObject.GetComponent<Text>().text.Replace(TextManager.Instance.GetText(oldStringIndex), stringAtStart);

//            if (gameObject.GetComponent<TextMeshPro>() != null)
//                gameObject.GetComponentInChildren<TextMeshPro>(true).text = gameObject.GetComponent<TextMeshPro>().text.Replace(TextManager.Instance.GetText(oldStringIndex), stringAtStart);
//        }

//        public void ReplaceText()
//    {
//            if(textIsInitialized)
//            { if (gameObject.GetComponent<Text>() != null)
//                    gameObject.GetComponentInChildren<Text>(true).text = gameObject.GetComponent<Text>().text.Replace(TextManager.Instance.GetText(oldStringIndex), NewString);

//                if (gameObject.GetComponent<TextMeshPro>() != null)
//                    gameObject.GetComponentInChildren<TextMeshPro>(true).text = gameObject.GetComponent<TextMeshPro>().text.Replace(TextManager.Instance.GetText(oldStringIndex), NewString);
//            }
//            else
//            {
//                callOnStart = true;
//                stringAtStart = NewString;

//            }
//        }

//}
//}