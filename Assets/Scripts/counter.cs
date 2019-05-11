using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{
    int players = 0;
    public void PlayerPP()
    {
        players++;
    }
    public void PlayerMM()
    {
        players--;
    }
    public int ReturnPlayers()
    {
        return players;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
