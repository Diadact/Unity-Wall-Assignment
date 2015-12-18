using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	void Start () {
	
	}
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
