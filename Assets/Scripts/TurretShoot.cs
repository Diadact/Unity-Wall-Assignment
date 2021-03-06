﻿using UnityEngine;
using System.Collections;

public class TurretShoot : MonoBehaviour {

    public Transform enemy;
    public float distance;

    public float speed = 100;
    public Rigidbody projectile;
    public float AutoDelay = 0.3f;
    private float AutoTimer = 0.0f;
    public float MaxAmmo = 100;
    private float Ammo;
    public float ReloadDelay = 4.0f;
    private float ReloadTimer = 0.0f;
    bool reloading = false;
    public float ammoLeft;

    PlayerHP playerHP;

    void Start(){

        Ammo = MaxAmmo;
        ammoLeft = MaxAmmo;
    }
         
	void Update () {

        if(enemy != null)
        {
            distance = Vector3.Distance(enemy.position, transform.position);

            Debug.Log(distance);
            if (distance <= 160)
            {
                transform.LookAt(enemy);
            }

            if (distance <= 80)
            {
                AutoTimer += Time.deltaTime;
                if (AutoTimer >= AutoDelay)
                {
                    Debug.Log("Shooting Enemy");
                    AutoTimer = 0.0f;

                    Rigidbody instantiateProjectile = Instantiate(projectile, transform.position + transform.TransformDirection(Vector3.forward*4), transform.rotation) as Rigidbody;
                    instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                    ammoLeft--;
                    Ammo--;
                }
            }
        }	
	}
}
