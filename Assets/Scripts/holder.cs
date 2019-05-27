using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holder : MonoBehaviour
{
	GameObject mainPistol;
	[SerializeField] GameObject ground3;
    // Start is called before the first frame update
	public GameObject ReturnGround()
	{
		return ground3;
	}
    void Start()
    {
	TankPistol[] hold = FindObjectsOfType<TankPistol>();
foreach(TankPistol i in hold)      {if(transform.IsChildOf(i.gameObject.transform))
{
	mainPistol = i.gameObject;
	mainPistol.GetComponent<TankPistol>().GetHolder(gameObject);
}
}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
