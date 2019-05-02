using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// вызов событий при входе и выходе из коллайдера 3D объекта
/// </summary>
public class RaycastMask : MonoBehaviour
{
    [HideInInspector]
    public Camera cam;
    int prevTransparency = 0;

    [Space(20)]
    public UnityEvent OnMaskMouseEnter;
    public UnityEvent OnMaskMouseExit;
    [Space(20)]

    public bool allowCallEventByClick = false;

    public int curEventIndex = 0;
    [Space(10)]
    public UnityEvent[] OnMaskPressEvents;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
      if (allowCallEventByClick)
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));//   Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2500))
            {
                Renderer thisRend = GetComponent<Renderer>();
                MeshCollider thisMeshCollider = GetComponent<MeshCollider>();

                if (thisRend == null || thisRend.sharedMaterial == null || thisRend.sharedMaterial.mainTexture == null || thisMeshCollider == null)
                    return;

                Texture2D thisTex = thisRend.material.mainTexture as Texture2D;
                Vector2 hPixelUV = hit.textureCoord;
                hPixelUV.x *= thisTex.width;
                hPixelUV.y *= thisTex.height;


                if (thisTex.GetPixel((int)hPixelUV.x, (int)hPixelUV.y).a > 0.5f)
                {
                    OnMaskPressEvents[curEventIndex].Invoke();
                    curEventIndex++;
                    if (curEventIndex == OnMaskPressEvents.Length)
                    {
                        curEventIndex = 0;
                    }
                }
            }
        }


        ////  остлеживать луч по середине экрана   или по позиции курсора
        Ray rayUpdate = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));//   Input.mousePosition);
        RaycastHit hitUpdate;
        if (Physics.Raycast(rayUpdate, out hitUpdate, 2500))
        {
            Renderer thisRend = GetComponent<Renderer>();
            MeshCollider thisMeshCollider = GetComponent<MeshCollider>();

            if (thisRend == null || thisRend.sharedMaterial == null || thisRend.sharedMaterial.mainTexture == null || thisMeshCollider == null)
                return;

            Texture2D thisTex = thisRend.material.mainTexture as Texture2D;
            Vector2 hPixelUV = hitUpdate.textureCoord;
            hPixelUV.x *= thisTex.width;
            hPixelUV.y *= thisTex.height;


            if (thisTex.GetPixel((int)hPixelUV.x, (int)hPixelUV.y).a > 0.5f)
            {
                if (prevTransparency == 0)
                {
                    OnMaskMouseEnter.Invoke();
                }
                prevTransparency = 1;
            }
            else
            {
                if (prevTransparency == 1)
                {
                    OnMaskMouseExit.Invoke();
                }

                prevTransparency = 0;
            }
        }
    }
}
