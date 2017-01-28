using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclesController : MonoBehaviour {
    public float speed = 5f;
    public GameObject[] prefabs = new GameObject[2];
    public List<GameObject>[] obstacles = new List<GameObject>[2];
    public Transform bird;

	// Use this for initialization
	void Start ()
    {
        obstacles[0] = new List<GameObject>();
        obstacles[1] = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        int sw = Screen.width;
        int sh = Screen.height;
        int count = obstacles[0].Count;
        bool isAdd = false;

        if (count > 0)
        {
            List<GameObject> top = obstacles[0];
            List<GameObject> bottom = obstacles[1];

            for (int i = 0; i < count; i++)
            {
                top[i].transform.Translate(Vector3.right * -speed * Time.deltaTime);
                bottom[i].transform.Translate(Vector3.right * -speed * Time.deltaTime);
                Vector3 pos = Camera.main.WorldToScreenPoint(top[i].transform.position);

                if (pos.x < 0)
                {
                    Destroy(top[i]);
                    Destroy(bottom[i]);
                    top.RemoveAt(i);
                    bottom.RemoveAt(i);

                    if (--count <= 0)
                    {
                        isAdd = true;
                        break;
                    }
                }

                if (!isAdd)
                {
                    Vector3 p = Camera.main.WorldToScreenPoint(top[count - 1].transform.position);
                    if (p.x < sw)
                    {
                        isAdd = true;
                    }
                }
            }
        }
        else isAdd = true;

        if (isAdd)
        {
            float btw = Random.Range(250, 450);
            Vector3 pos = new Vector3(sw + Random.Range(200, 400), sh / 2 + Random.Range(-50, 50), 10);
            pos.y += btw / 2;
            GameObject obstacle = Instantiate<GameObject>(prefabs[0]);
            obstacle.transform.position = Camera.main.ScreenToWorldPoint(pos) + Vector3.forward * bird.position.z + Vector3.right * 4f;
            obstacles[0].Add(obstacle);

            pos.y -= btw;
            obstacle = Instantiate<GameObject>(prefabs[1]);
            obstacle.transform.position = Camera.main.ScreenToWorldPoint(pos) + Vector3.forward * bird.position.z + Vector3.right * 4f;
            obstacles[1].Add(obstacle);
        }
	}
}
