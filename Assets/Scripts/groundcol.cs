using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int coll = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
            coll = 0;
            if (GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ReturnFoot1().GetComponent<feet1>().GetColl() == 0)
            { GetComponent<OgTank>().ReturnTank().GetComponent<tank>().GravityZero(); }

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
            coll = 0;
            if (GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ReturnFoot1().GetComponent<feet1>().GetColl() == 0)
            { GetComponent<OgTank>().ReturnTank().GetComponent<tank>().GravityZero(); }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ResetJumps();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ResetJumps();
        }
    }
}
