using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgTank : MonoBehaviour
{
    [SerializeField] GameObject ogTank;

    public void GetOgTank(GameObject origTank)
    {
        ogTank = origTank;
    }
    public GameObject ReturnTank()
    {
        return ogTank;
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
