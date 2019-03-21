using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSection : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    public int sectionId;
    public int nextId;
    public bool startLine = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == TAG_PLAYER)
        {
            RaceManager raceManager = other.gameObject.GetComponent<RaceManager>();
            if (!startLine)
                raceManager.enterNextSection(sectionId, nextId);
            else
                raceManager.enterStartSection(sectionId, nextId);
        }
    }
}
