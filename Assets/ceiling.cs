using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceiling : MonoBehaviour
{
    int colliding = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bullet" && !transform.IsChildOf(gameObject.transform))
            colliding++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "bullet" && !transform.IsChildOf(gameObject.transform))
            colliding--;
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
