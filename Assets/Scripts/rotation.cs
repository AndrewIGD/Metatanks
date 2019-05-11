using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject point;
    [SerializeField] GameObject secondobj;
    [SerializeField] GameObject mortarpoint;
    [SerializeField] Vector3 axis = new Vector3(0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point.transform.position, axis, Time.deltaTime * 10);
        secondobj.transform.position = Vector2.MoveTowards(secondobj.transform.position, mortarpoint.transform.position, Time.deltaTime / 20);
    }
}

    

