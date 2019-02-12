using UnityEngine;
using System.Collections;

public class TimeCapsule: MonoBehaviour {
    // target impact on game
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;
    public int healthAmount = 0;

    // explosion when hit?
    public GameObject explosionPrefab;

    void OnTriggerEnter(Collider collision)
    {

        if (this.tag == "TimeCapsule" && collision.gameObject.tag == "BallBlue")
        {

            return;
        }

        if (this.tag == "TimeCapsule" && collision.gameObject.tag == "BallRed") // if the player got hit with it's own bullets, ignore it
        {

            return;
        }
        if (this.tag == "TimeCapsule" && collision.gameObject.tag == "DamageCube") // if the player got hit with it's own bullets, ignore it
        {
            Destroy(this.gameObject);
            return;
        }
        if (this.tag == "TimeCapsule")
        {
            if (GameManager.gm)
            {

                if (GameManager.gm.health < 100)
                {
                    int positivehealth = -(healthAmount);
                    GameManager.gm.damagehit(positivehealth);
                    
                }
                GameManager.gm.targetHit(scoreAmount, timeAmount);


                Destroy(this.gameObject);      // destroy the object whenever it hits something


                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                }

            }
        }
    }
    
}
