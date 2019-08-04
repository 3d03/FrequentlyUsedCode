using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializationTests { 
    public class SerializationController : MonoBehaviour
    {
        public GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            RestoreGame();
        }
        void RestoreGame()
        {
            string p = PlayerPrefs.GetString("PlayerPosition");
            if (p!=null &&p.Length>0)
            {
                PositionSaver s = JsonUtility.FromJson<PositionSaver>(p);
                if (s!=null)
                {
                    Vector3 pos = new Vector3();
                    pos.x = s.x;
                    pos.y = s.y;
                    pos.z = s.z;

                    player.transform.position = pos;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                saveGame();
            }
        }


        void saveGame()
        {
            PositionSaver positionSaver = new PositionSaver();
            positionSaver.x = player.transform.position.x;
            positionSaver.y = player.transform.position.y;
            positionSaver.z = player.transform.position.z;
            string json = JsonUtility.ToJson(positionSaver);
            Debug.Log(json);
            PlayerPrefs.SetString("PlayerPosition", json);
        }
    }
}