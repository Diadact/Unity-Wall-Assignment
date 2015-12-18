using UnityEngine;
using System.Collections;

public class HpPickup : MonoBehaviour
{
    public Transform player;
    PlayerHP playerhp;
    bool playerColliding = false;

	void Start ()
    {
        playerhp = player.GetComponent<PlayerHP>();        
    }
	
	void Update ()
    {
	    
	}
}
