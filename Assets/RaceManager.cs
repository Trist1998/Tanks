using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public int lap;
    public int currentSectionId;

    public void enterNextSection(int sectionId, int nextExpectedId)
    {
        if(sectionId == expectedNextSectionId)
        {
            currentSectionId = sectionId;
            expectedNextSectionId = nextExpectedId;
        }
    }

    internal void enterStartSection(int sectionId, int nextId)
    {
        if (sectionId == expectedNextSectionId)
        {
            currentSectionId = sectionId;
            expectedNextSectionId = nextId;
            lap++;
        }
    }
}
