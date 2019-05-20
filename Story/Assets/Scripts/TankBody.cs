using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBody : MonoBehaviour
{
    [SerializeField] float hp;
    float weight;
    GameObject body;

    //Functii
    public void GetBody(GameObject b)
    {
        body = b;
    }
    public GameObject ReturnBody()
    {
        return body;
    }
    public void GetHp(float hpp)
    {
        hp = hpp;
    }
    public void GetWeight(float w)
    {
        weight = w;
    }
    public float ReturnHp()
    {
        return hp;
    }
    public float ReturnWeight()
    {
        return weight;
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
