using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMover : MonoBehaviour
{
    public float speed;
    public Car car;
    public List<Car> cars;
    string json;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.S))
        {
            json= JsonUtility.ToJson(car);
            Debug.Log(json);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            Car duplicatedCar = JsonUtility.FromJson<Car>(json);
            counter++;
            duplicatedCar.brand += counter.ToString();
            duplicatedCar.model += counter.ToString();
            cars.Add(duplicatedCar);
        }





        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position =  transform.position;
            position.x += speed;
            transform.position = position;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = transform.position;
            position.x -= speed;
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = transform.position;
            position.y += speed;
            transform.position = position;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = transform.position;
            position.y -= speed;
            transform.position = position;
        }
    }
}
