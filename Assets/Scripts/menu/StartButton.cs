using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    bool start = false;
    float timer = 1.0f;
    int countDown = 3;
    public TextMesh text;
    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if (countDown > -1)
            {
                timer -= Time.deltaTime;
                if(timer < 0)
                {
                    countDown--;
                    timer = 1.0f;
                }
                text.text = countDown == 0 ? "GO!" : countDown + "";
                
            }
            else
            {
                GameStateManager.play();
                Destroy(gameObject);
            }
                
        }
    }

    void OnMouseUp()
    {
        start = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
