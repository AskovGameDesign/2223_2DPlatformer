using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public UnityEvent playerDiedEvent; 

    // Start is called before the first frame update
    void Start()
    {
        //playerDiedEvent.AddListener(PlayerDied);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        Debug.Log("Manager said player died");
    }

    public void PlayerDamage(int damage)
    {
        playerLives -= damage;

        if(playerLives <= 0)
        {
            playerDiedEvent.Invoke();
        }
    }
}
