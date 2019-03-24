using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInGameState : MonoBehaviour
{
    private Vector3 showPosition;
    public int stateId;
    void Start()
    {
            showPosition = transform.position;
    }
    void FixedUpdate()
    {
        if (GameStateManager.gameStateId == stateId)
        {
            //gameObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.position = new Vector3(transform.parent.position.x + showPosition.x, transform.parent.position.y + showPosition.y, showPosition.z);
        }
        else
        {
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            transform.position = new Vector3(1000.0f, 1000.0f, 1000.0f);
        }
            
    }
}
