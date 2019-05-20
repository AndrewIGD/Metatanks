using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheels : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float hp;
    GameObject mainWheels;

	public float ReturnHp()
	{
		return hp;
	}
    // Start is called before the first frame update
    void Start()
    {
        TankWheels[] wheels = FindObjectsOfType<TankWheels>();
        foreach (TankWheels i in wheels)
        {
            if (transform.IsChildOf(i.gameObject.transform))
            {
                mainWheels = i.gameObject;
                mainWheels.GetComponent<TankWheels>().GetSpeed(speed);
                mainWheels.GetComponent<TankWheels>().GetHp(hp);
                mainWheels.GetComponent<TankWheels>().GetWheels(gameObject);
            }
        }
    }
    public float ReturnSpeed()
    {
        return speed;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
