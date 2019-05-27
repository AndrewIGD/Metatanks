using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player : NetworkBehaviour
{
    [SerializeField] GameObject tankSelector;
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject clone = Instantiate(tankSelector);
        NetworkServer.SpawnWithClientAuthority(clone, connectionToClient);
    }
}
