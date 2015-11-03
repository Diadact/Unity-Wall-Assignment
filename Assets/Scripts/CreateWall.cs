using UnityEngine;
using System.Collections;

public class CreateWall : MonoBehaviour {

    public GameObject wall;

	// Use this for initialization
	void Start () {


        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GameObject instantiateWall = Instantiate(wall, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z), transform.rotation) as GameObject;
                Debug.Log("Wall Created");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
