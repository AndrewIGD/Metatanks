using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockets : MonoBehaviour
{
    [SerializeField] GameObject rocket1;
    [SerializeField] GameObject rocket2;
    [SerializeField] Vector3 rocket1Pos;
    [SerializeField] Vector3 rocket2Pos;
    [SerializeField] Vector3 rocket1Pos2;
    [SerializeField] Vector3 rocket2Pos2;
    bool check = false;
    public GameObject ReturnRocket1()
    {
        return rocket1;
    }
    public GameObject ReturnRocket2()
    {
        return rocket2;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SelectScene")
        {
            rocket1.transform.localPosition = rocket1Pos;
            rocket2.transform.localPosition = rocket2Pos;
        }
        if (check == false)
        {
            if (SceneManager.GetActiveScene().name != "SelectScene")
            {
                rocket1.transform.localPosition = rocket1Pos2;
                rocket2.transform.localPosition = rocket2Pos2;
                check = true;
            }
        }
    }
}
