using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
