using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeGameState : MonoBehaviour
{
    public int gameStateId;
    void OnMouseUp()
    {
        GameStateManager.gameStateId = gameStateId;
    }
}
