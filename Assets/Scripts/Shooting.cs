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

	// Use this for initialization
	void Start ()
    {
        Ammo = MaxAmmo;
        ammoLeft = MaxAmmo;

        currentAmmo.text = "Ammo: " + ammoLeft.ToString();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AutoTimer += Time.deltaTime;
        if(AutoTimer >= AutoDelay)
        {
		    if(Input.GetButton("Fire1") && Ammo > 0 && reloading == false)
            {
                AutoTimer = 0.0f;

                Rigidbody instantiateProjectile = Instantiate(projectile,transform.position,transform.rotation) as Rigidbody;
			    instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0,0,speed));
                ammoLeft--;
                currentAmmo.text = "Ammo: " + ammoLeft.ToString();
                Ammo--;                       
		    }         
        }
        if (Ammo == 0)
        {
            reloadText.text = "Reload (R)";
            Debug.Log("Out of Ammo");
        }
        if (Input.GetKeyDown(KeyCode.R))
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
            ammoLeft = MaxAmmo;
            currentAmmo.text = "Ammo: " + ammoLeft.ToString();
            Ammo = MaxAmmo;
            reloading = false;
            ReloadTimer = 0.0f;
            reloadText.text = "";
        }       
    }
}
