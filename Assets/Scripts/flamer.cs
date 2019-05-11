using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flamer : MonoBehaviour
{
    [SerializeField] Vector3 flamerPos;
        int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check == 0)
        {
            if (SceneManager.GetActiveScene().name != "SelectScene" && GetComponent<OgTank>().ReturnTank() != null)
            {
                check = 1;
                GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ReturnHolder().transform.localPosition = flamerPos;
            }
        }
    }
}
