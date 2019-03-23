using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSection : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    public int sectionId;
    public bool last = false;

    //Used for winning camera
    public bool horizontal;//false for vertical
    public bool positive;//

    void Start()
    {
        TrackManager manager = GetComponentInParent<TrackManager>();
        if (manager != null)
            manager.addSection(this);
        else
            print("Error TrackSection not managed by TrackManager");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == TAG_PLAYER)
        {
            RaceManager raceManager = other.gameObject.GetComponent<RaceManager>();
            if (!last)
                raceManager.enterNextSection(sectionId);
            else
                raceManager.enterLastSection(sectionId);
        }
    }

    public GameObject getLeadingPlayer(List<RaceManager> leaders)
    {
        GameObject leader = null;
        foreach (RaceManager player in leaders)
        {
            GameObject playerObject = player.gameObject;
            if (leader == null)
                leader = playerObject;
            else
            {
                if(horizontal)
                {
                    leader = (leader.transform.position.x > playerObject.transform.position.x) == positive ? leader : playerObject;
                }
                else//vertical
                {
                    leader = (leader.transform.position.y > playerObject.transform.position.y) == positive ? leader : playerObject;
                }
            }
        }

        return leader;
    }
}
