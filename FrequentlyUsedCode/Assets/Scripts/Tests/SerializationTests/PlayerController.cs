using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializationTests { 
    public class PlayerController : MonoBehaviour
    {
        public float speed = 0.1f;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
          if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 position = transform.position;
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
}