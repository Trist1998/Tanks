using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretController : MonoBehaviour
{

    public float rotationSpeed;
    public float timer;
    public float reloadTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, -1) * rotationSpeed);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F))
        {
            if (timer < 0)
            {
                timer = reloadTime;
                fire();
            }
        }       
    }

    private void fire()
    {      
        GameObject missile = Instantiate(Resources.Load("Prefabs/Vehicle/Turret/MissilePrefab")) as GameObject;
        missile.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        missile.transform.rotation = transform.rotation;
    }

}
