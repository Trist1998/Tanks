using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePredator : MonoBehaviour
{
    public TrackManager manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Fire");
        GameObject missile = Instantiate(Resources.Load("Prefabs/Vehicle/Turret/PredatorMissilePrefab")) as GameObject;
        missile.transform.position = new Vector3(10, 10, transform.position.z);
        missile.transform.rotation = transform.rotation;
        missile.GetComponent<Missile>().firer = gameObject;
        missile.GetComponent<Missile>().target = manager.getLeadingPlayer();

    }
}
