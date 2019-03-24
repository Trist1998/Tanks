using UnityEngine;
using System.Collections;
using System;

public class Missile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float timer;
    public GameObject firer;
    public ParticleSystem explosion;
    public GameObject target;
    public float rotationSpeed;
	// Use this for initialization
	void Start ()
    {
	    
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (target != null)
            flyToTarget();
        transform.position += transform.right * Time.deltaTime * speed;
        if (GameStateManager.isEnd())
            Destroy(gameObject);
    }

    private void flyToTarget()
    {
        Vector3 diff = target.transform.position - transform.position;
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != firer && (collision.gameObject.tag == "vehicle" || collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(damage);
            explosion.Emit(300);
            Destroy(this.gameObject);
        }
    }
}
