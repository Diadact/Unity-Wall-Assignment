using UnityEngine;
using System.Collections;

public class TurretHp : MonoBehaviour {

    public float MaxHP = 100.0f;
    public float DMG = 10.0f;

	void Start () {
	
	}
	
	void Update () {
        
        if(MaxHP == 0)
        {
            Destroy(gameObject);
        }	
	}

    void OnCollisionEnter(Collision other)
    {
        MaxHP -= DMG;

    }
}
