using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leg1 : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" && !collision.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
        {
            GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ResetJumps();
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
