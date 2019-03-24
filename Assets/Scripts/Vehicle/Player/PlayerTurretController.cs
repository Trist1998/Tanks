using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretController : MonoBehaviour
{

    public float rotationSpeed;
    public float timer;
    public float reloadTime;
    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }
    private float getRotateAxis()
    {
        if (playerNumber == 1)
            return Input.GetAxis("Player1_Turret_Turn");
        return Input.GetAxis("Player2_Turret_Turn");
    }

    private float getFireAxis()
    {
        if (playerNumber == 1)
            return Input.GetAxis("Fire1");
        return Input.GetAxis("Fire2");
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * getRotateAxis());
        timer -= Time.deltaTime;

        if (getFireAxis() != 0 && GameStateManager.isPlay())
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
        missile.GetComponent<Missile>().firer = transform.parent.gameObject;
    }

}
