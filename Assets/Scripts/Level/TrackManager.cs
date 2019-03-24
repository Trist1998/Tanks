using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public Dictionary<int, TrackSection> sections = new Dictionary<int, TrackSection>();
    public Dictionary<int, RaceManager> players = new Dictionary<int, RaceManager>();
    public List<int> playerIds = new List<int>();
    public TextMesh win;


    public void addSection(TrackSection toAdd)
    {
        sections.Add(toAdd.sectionId, toAdd);
    }

    public void addPlayer(RaceManager toAdd)
    {
        playerIds.Add(toAdd.playerId);
        players.Add(toAdd.playerId, toAdd);

    }

    public GameObject getLeadingPlayer()
    {
        int maxLap = 0;
        int maxId = 0;      
        List<RaceManager> leaders = new List<RaceManager>();
        foreach (int playerId in playerIds)
        {
            RaceManager player = players[playerId];
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

    internal void playerDead(int id)
    {
        GameStateManager.end();
        int winnerId = 0;
        foreach(int i in playerIds)
        {
            if(i != id)
            {
                winnerId = i;
                break;
            }
        }

        win.text = "Player " + winnerId + "\n WINS!!!"; 
    }

}
