using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINI_LevelGenerator : MonoBehaviour {

    public GameObject prefabObstacle;
    public Vector2 startingPos;
    public Vector2 endingPos;

    private int randomObstacles;

    void Start () {

        for(float i = startingPos.x; i < endingPos.x; i+=15)
        {
            randomObstacles = Random.Range(0, 150);
            if (randomObstacles < 30)
                i += 6;
            else if(randomObstacles < 60)
            {
                GameObject temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y);
            }
            else if(randomObstacles < 100)
            {
                GameObject temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y);
                temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y + 1);
            }
            else if (randomObstacles < 110)
            {
                GameObject temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y);
                temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i+1, startingPos.y);
                temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y + 1);
            }
            else
            {
                GameObject temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y);
                i += 1;
                temp = GameObject.Instantiate(prefabObstacle);
                temp.transform.position = new Vector3(i, startingPos.y);
            }
            
        }
	}
	
}
