using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWheels : MonoBehaviour
{
    GameObject wheels;
    float speed;
    float hp;

    public void GetWheels(GameObject wh)
    {
        wheels = wh;
    }
    public GameObject ReturnWheels()
    {
        return wheels;
    }
    public void GetSpeed(float sp)
    {
        speed = sp;
    }
    public float ReturnHp()
    {
        return hp;
    }
    public float ReturnSpeed()
    {
        return speed;
    }
    public void GetHp(float hpp)
    {
        hp = hpp;
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
