using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followLeader : MonoBehaviour
{
    public TrackManager manager;
    public float speed;
    public float xBound;
    public float yBound;

    void Start()
    {
        manager = GetComponentInParent<TrackManager>();
        if (manager == null)
            print("Follow Camera has no Track Manager");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameStateManager.isPlay())
        {
            followObject(manager.getLeadingPlayer());
        }
    }

    private void followObject(GameObject target)
    {
        if (Mathf.Abs(gameObject.transform.position.x - target.transform.position.x) > xBound || Mathf.Abs(gameObject.transform.position.y - target.transform.position.y) > yBound)
        {
            Vector3 displacement = target.transform.position - gameObject.transform.position;

            gameObject.transform.position += new Vector3(displacement.normalized.x * Time.deltaTime * speed, displacement.normalized.y * Time.deltaTime * speed, 0);

        }
    }
}
