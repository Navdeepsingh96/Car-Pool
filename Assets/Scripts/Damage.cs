using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public int damageAmount = 20;
	
	public GameObject explosionPrefab;
    

	void OnCollisionEnter(Collision collision) 						// this is used for things that explode on impact and are NOT triggers
	{	
		
            if (this.tag == "DamageCube" && collision.gameObject.tag == "BallBlue") // if the player got hit with it's own bullets, ignore it
            {
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);
                return;
            }
            if (this.tag == "DamageCube" && collision.gameObject.tag == "BallRed") // if the player got hit with it's own bullets, ignore it
            {
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }
                Destroy(this.gameObject);
                return;
            }
            if (this.tag == "DamageCube" && collision.gameObject.tag == "Player")
            {
                if (GameManager.gm)
                {
                    GameManager.gm.damagehit(damageAmount);
                }


                
                    Destroy(this.gameObject);      // destroy the object whenever it hits something
                

                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }

            }
        }
	


	
	
}