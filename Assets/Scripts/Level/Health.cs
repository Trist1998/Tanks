using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float healthPoints;
    public GameObject healthBar;
    public TrackManager manager;

    public void takeDamage(float hitPoints)
    {
        healthPoints -= hitPoints;
        if(healthPoints <= 0)
        {
            healthPoints = 0;
            if (manager != null)
                manager.playerDead(gameObject.GetComponent<RaceManager>().playerId);
        }

        if (healthBar != null)
            healthBar.transform.localScale = new Vector3(healthPoints / 100.0f, healthBar.transform.localScale.y, 1);
    }
}
