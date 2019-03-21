using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
    public float speed;
    public float damage;
    public float timer;
	// Use this for initialization
	void Start ()
    {
	    
	}

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += transform.right * Time.deltaTime * speed;
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
        if(collision.gameObject.tag == "vehicle")
        {
            Destroy(this.gameObject);
        }
    }
}
