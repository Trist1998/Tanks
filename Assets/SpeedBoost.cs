using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private const string TAG_PLAYER = "Player";
    public float boostVelocity;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TAG_PLAYER)
        {
            other.gameObject.GetComponent<PlayerController>().boost(boostVelocity);
        }
    }
}
