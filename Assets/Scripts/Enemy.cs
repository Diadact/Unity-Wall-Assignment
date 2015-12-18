using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    PlayerHP playerhp;
    public float distance;
    public float MaxHP = 50;
    public float CurrentHP;
    public int speed = 5;
    public bool doingDmg = false;
    public ParticleSystem particles;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerhp = player.GetComponent<PlayerHP>();
        CurrentHP = MaxHP;
    }
	
	void Update ()
    {
        if (CurrentHP > 0)
        {
            distance = Vector3.Distance(player.position, transform.position);

            if(distance <= 10000)
            {
                transform.LookAt(player);
                gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed)) + new Vector3(0,-1,0);
            }
        }
        if (CurrentHP <= 0)
        {
            ParticleSystem p = Instantiate(particles, transform.position, transform.rotation) as ParticleSystem;
            Destroy(p, 1);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile") && CurrentHP > 0)
        {
            CurrentHP -= 10;
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && playerhp.CurrentHp > 0 && doingDmg == false)
        {
            playerhp.CurrentHp -= 5;
            doingDmg = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            doingDmg = false;
        }
    }
}

