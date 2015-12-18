using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooting : MonoBehaviour {

	public float speed = 100;
	public Rigidbody projectile;
    public float AutoDelay = 0.1f;
    private float AutoTimer = 0.0f;
    public float MaxAmmo = 20;
    private float Ammo;
    public Text reloadText;
    public Text currentAmmo;
    public float ReloadDelay = 2.0f;
    private float ReloadTimer = 0.0f;
    bool reloading = false;
    public float ammoLeft;
    public Transform targeting;
    public float spareAmmo = 100;
    public float ammoNeeded = 0;
    public float restOfAmmo;
    bool outOfAmmo = false;

	// Use this for initialization
	void Start ()
    {
        Ammo = MaxAmmo;
        ammoLeft = MaxAmmo;
        restOfAmmo = spareAmmo;

        currentAmmo.text = "Ammo: " + ammoLeft.ToString() + "/" + spareAmmo.ToString();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AutoTimer += Time.deltaTime;

        currentAmmo.text = "Ammo: " + ammoLeft.ToString() + "/" + spareAmmo.ToString();

        if (AutoTimer >= AutoDelay)
        {
		    if(Input.GetButton("Fire1") && Ammo > 0 && reloading == false && ammoLeft > 0)
            {
                RaycastHit hit;
                Physics.Raycast(targeting.position, targeting.forward, out hit);

                AutoTimer = 0.0f;

                if (hit.collider != null && hit.point != Vector3.zero)
                {
                    transform.LookAt(hit.point);
                }

                Rigidbody instantiateProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody;
			    instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed));
                ammoLeft--;
                currentAmmo.text = "Ammo: " + ammoLeft.ToString() + "/" + spareAmmo.ToString();
                Ammo--;
                ammoNeeded++;
                restOfAmmo--;                 
		    }         
        }
        if (spareAmmo <= 0)
        {
            outOfAmmo = true;
        }

        if (Ammo == 0)
        {
            reloadText.text = "Reload (R)";
            Debug.Log("Out of Ammo");
        }
        if (Input.GetKeyDown(KeyCode.R) && outOfAmmo != true)
        {
            reloading = true;            
        }

        if(reloading == true)
        {
            ReloadTimer += Time.deltaTime;
            Debug.Log(ReloadTimer + " " + ReloadDelay);
        }

        if (ReloadTimer >= ReloadDelay)
        {
            if (spareAmmo > MaxAmmo)
            {
                ammoLeft = MaxAmmo;
                currentAmmo.text = "Ammo: " + ammoLeft.ToString() + "/" + spareAmmo.ToString();
                Ammo = MaxAmmo;
                reloading = false;
                ReloadTimer = 0.0f;
                ammoNeeded = 0.0f;
                spareAmmo = restOfAmmo;
                reloadText.text = "";
            }
            else
            {
                ammoLeft = spareAmmo;
                currentAmmo.text = "Ammo: " + ammoLeft.ToString() + "/" + spareAmmo.ToString();
                Ammo = MaxAmmo;
                reloading = false;
                ReloadTimer = 0.0f;
                ammoNeeded = 0.0f;
                spareAmmo = 0;
                reloadText.text = "";
            }
        }       
    }
}
