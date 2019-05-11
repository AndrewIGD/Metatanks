using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet1 : MonoBehaviour
{
    [SerializeField] GameObject running1;
    [SerializeField] GameObject running2;
    [SerializeField] GameObject running3;
    [SerializeField] GameObject running4;
    [SerializeField] GameObject idle;
    [SerializeField] GameObject idle2;
    [SerializeField] GameObject jump1;
    [SerializeField] GameObject jump2;
    [SerializeField] GameObject untransformed;
    public GameObject ReturnUntransformed()
    {
        return untransformed;
    }
    int coll = 0;
    public GameObject ReturnJump2()
    {
        return jump2;
    }
    public GameObject ReturnJump1()
    {
        return jump1;
    }
    public GameObject ReturnIdle2()
    {
        return idle2;
    }
    public GameObject ReturnIdle()
    {
        return idle;
    }
    public GameObject ReturnRun4()
    {
        return running4;
    }
    public GameObject ReturnRun3()
    {
        return running3;
    }
    public GameObject ReturnRun1()
    {
        return running1;
    }
    public GameObject ReturnRun2()
    {
        return running2;
    }
    public int GetColl()
    {
        return coll;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
coll = 1;
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ResetJumps();
        }
        else if (collision.gameObject.tag == "bullet")
        {
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().DecreaseHp(collision.GetComponent<bullet>().ReturnDamage(), false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
coll = 1;
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ResetJumps();
        }
        else if (collision.gameObject.tag == "bullet")
        {
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().DecreaseHp(collision.gameObject.GetComponent<bullet>().ReturnDamage(), false);
        }
    }
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
