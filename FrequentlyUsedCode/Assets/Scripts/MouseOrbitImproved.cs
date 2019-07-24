using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;


public class MouseOrbitImproved : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;


    float x = 0.0f;
    float y = 0.0f;

    Vector3 mousePos = Vector2.zero;
    public bool isMobile = false;
    float touchD = 0.0f;

    public float zoomSpeed = 3.0f;
    bool savePos = false;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        

        if (isMobile)
        {
            mousePos = GetTouchPos();
        }
        else {
            mousePos = Input.mousePosition;
        }
        UpdateCamera(0.0f, mousePos);
    }

    void FixedUpdate()
    {
        if (target)
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (isMobile)
                {
                    if (Input.touchCount > 0)
                    {
                        mousePos = GetTouchPos();

                        if (Input.touchCount > 1)
                        {
                            Touch touch = Input.GetTouch(1);
                            if (!savePos && touch.phase == TouchPhase.Began)
                            {
                                savePos = true;
                                touchD = Vector2.Distance(touch.position, mousePos);
                                //????
                                distance = Vector3.Distance(this.gameObject.transform.position, target.position);
                            }
                        }
                        else {
                            savePos = false;
                        }
                    }
                    else {
                        savePos = false;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        mousePos = Input.mousePosition;
                        distance = Vector3.Distance(this.gameObject.transform.position, target.position);
                    }
                }

                //if (Input.GetMouseButton(0))
                if (!isMobile)
                {
                    if (Input.GetMouseButton(0))
                    {
                        UpdateCamera(0.0f, Input.mousePosition);
                    }
                    else if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
                    {
                        UpdateCamera(Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, mousePos);
                    }
                }
                else
                {
                    if (Input.touchCount > 1) {
                        Touch touch = Input.GetTouch(0);
                        Touch touch2 = Input.GetTouch(1);
                        float d = Vector2.Distance(touch.position, touch2.position);
                        UpdateCamera((d - touchD) / 10.0f, mousePos);
                        touchD = d;
                    }
                    else if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        UpdateCamera(0.0f, new Vector3(touch.position.x, touch.position.y, 0.0f));//
                    }
                }
            }
    }

    public Vector3 GetTouchPos()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                return new Vector3(touch.position.x, touch.position.y, 0.0f);
            }
        }

        return mousePos;
    }

    public void OnZoom(bool zoomIn)
    {
        UpdateCamera(zoomIn ? 2.0f : -2.0f, mousePos);
    }

    void UpdateCamera(float zoom, Vector3 newPos)
    {
        Vector3 move = newPos - mousePos;
        move /= 10.0f;

        x += (move.x) * xSpeed * distance * 0.02f;
        y -= (move.y) * ySpeed * 0.02f;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        distance = Mathf.Clamp(distance - zoom, distanceMin, distanceMax);
        /*
        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }*/
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;

        mousePos = newPos;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}