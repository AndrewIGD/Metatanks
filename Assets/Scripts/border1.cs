using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border1 : MonoBehaviour
{
    [SerializeField] int border;
    [SerializeField] GameObject OGTANK;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetOgTank(GameObject tank)
    {
        OGTANK = tank;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "borders")
        {
            if (border == 1)
            {
                OGTANK.GetComponent<tank>().NotLeftMove();
            }
            else
            {
                OGTANK.GetComponent<tank>().NotRightMove();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    
        {
            if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "borders")
            {
                if (border == 1)
                {
                    OGTANK.GetComponent<tank>().LeftMove();
                }
                else
                {
                    OGTANK.GetComponent<tank>().RightMove();
                }
            }
        }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
