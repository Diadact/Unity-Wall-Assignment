using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour {

    public float MaxHp = 100.0f;
    private float CurrentHp;
    public Text HPText;

	void Start () {

        CurrentHp = MaxHp;	
	}
	
	void Update () {

        HPText.text = "Health: " + CurrentHp.ToString();

        if(CurrentHp == 0)
        {
            Debug.Log("You have Died");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Projectile") && CurrentHp > 0)
        {
            CurrentHp -= 10;
        }
    }
}
