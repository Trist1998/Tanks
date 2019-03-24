using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public int lap;
    public int currentSectionId;
    public int expectedId;
    public int playerId;

    void Start()
    {
        TrackManager manager = GetComponentInParent<TrackManager>();
        if (manager != null)
            manager.addPlayer(this);
        else
            print("Player not managed in track manager");

    }

    public void enterNextSection(int sectionId)
    {
        if(sectionId == expectedId)
        {
            currentSectionId = sectionId;
            expectedId = currentSectionId + 1;
        }
    }

    internal void enterLastSection(int sectionId)
    {
        if (sectionId == expectedId)
        {
            currentSectionId = 0;
            expectedId = 1;
            lap++;
        }
    }
}
