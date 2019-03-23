using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public Dictionary<int, TrackSection> sections = new Dictionary<int, TrackSection>();
    public List<RaceManager> players = new List<RaceManager>();

    public void addSection(TrackSection toAdd)
    {
        sections.Add(toAdd.sectionId, toAdd);
    }

    public void addPlayer(RaceManager toAdd)
    {
        players.Add(toAdd);
    }

    public GameObject getLeadingPlayer()
    {
        int maxLap = 0;
        int maxId = 0;      
        List<RaceManager> leaders = new List<RaceManager>();
        foreach (RaceManager player in players)
        {
            if(player.lap > maxLap || (player.lap == maxLap && player.currentSectionId > maxId))
            {
                leaders = new List<RaceManager>();
                leaders.Add(player);
                maxId = player.currentSectionId;
                maxLap = player.lap;
            }
            else if(player.lap == maxLap && player.currentSectionId == maxId)
            {
                leaders.Add(player);
            }
        }
        if (leaders.Count > 1)
            return sections[maxId].getLeadingPlayer(leaders);
        return leaders[0].gameObject;
    }
}
