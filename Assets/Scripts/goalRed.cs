using UnityEngine;
using System.Collections;

public class goalRed: MonoBehaviour {

    // target impact on game
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;
    public GameObject explosionPrefab;

    // explosion when hit?
    void OnCollisionEnter(Collision newCollision)
        
    {
        if (this.gameObject.tag=="BallRed" && newCollision.gameObject.tag == "GoalRed")
        {
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            // if game manager exists, make adjustments based on target properties
            if (GameManager.gm)
            {
                GameManager.gm.targetHit(scoreAmount, timeAmount);
            }

            // destroy after collection
            Destroy(this.gameObject);
        }
    }
}
