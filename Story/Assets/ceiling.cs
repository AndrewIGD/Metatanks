using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceiling : MonoBehaviour
{
    [SerializeField] int colliding = 0;
	bool check = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bullet" && !transform.IsChildOf(collision.gameObject.transform) && !collision.gameObject.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
		{colliding++; if(collision.gameObject.tag != "ground"){ Debug.Log("+" + collision.gameObject.name);}}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "bullet" && !transform.IsChildOf(collision.gameObject.transform) && !collision.gameObject.transform.IsChildOf(GetComponent<OgTank>().ReturnTank().transform))
		{colliding--; if(collision.gameObject.tag != "ground"){Debug.Log("-" + collision.gameObject.name);}}
    }
    public int ReturnColliding()
    {
        return colliding;
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
