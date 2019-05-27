using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mortar : MonoBehaviour
{
    [SerializeField] GameObject mortarTexture;
    [SerializeField] GameObject MST;
    [SerializeField] GameObject MSTPos;
    [SerializeField] Vector2 holderOgPos;
    [SerializeField] GameObject holder;
    [SerializeField] GameObject MYS;
    [SerializeField] Vector2 MYSpos;
    [SerializeField] Vector2 MYSscale;
    [SerializeField] Vector2 MortarPos;
    [SerializeField] GameObject point;
    [SerializeField] GameObject secondobj;
    [SerializeField] GameObject mortarpoint;
    [SerializeField] Vector3 axis = new Vector3(0, 0, 1);
    [SerializeField] int cannonBall = 0;
    bool check = false;
    public GameObject ReturnMortarTexture()
    {
        return MYS;
    }
    public void GetHolder(GameObject hold)
    {
        holder = hold;
    }
    public int ReturnCannonBall()
    {
        return cannonBall;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OgTank", 0.1f);
    }
    private void OgTank()
    {
        MST.GetComponent<OgTank>().GetOgTank(GetComponent<OgTank>().ReturnTank());
        mortarTexture.GetComponent<OgTank>().GetOgTank(GetComponent<OgTank>().ReturnTank());
    }
    public void RotateDreapta()
    {
        Debug.Log("exec");
        MYS.transform.RotateAround(point.transform.position, axis, Time.deltaTime * 40);
        secondobj.transform.position = Vector2.MoveTowards(secondobj.transform.position, mortarpoint.transform.position, Time.deltaTime / 40);
    }
    public void RotateStanga()
    {
        MYS.transform.RotateAround(point.transform.position, axis, -Time.deltaTime * 40);
        secondobj.transform.position = Vector2.MoveTowards(secondobj.transform.position, mortarpoint.transform.position, Time.deltaTime / 40);
    }
    // Update is called once per frame
    void Update()
    {
        MST.transform.position = MSTPos.transform.position;
        if (check == false)
        {
            if (SceneManager.GetActiveScene().name != "SelectScene")
            {
                holder.transform.localPosition = holderOgPos;
                MST.transform.localScale = new Vector3(1, 1, 1);
                MYS.transform.localPosition = MYSpos;
                MYS.transform.localScale = MYSscale;
                mortarTexture.transform.localPosition = MortarPos;

                check = true;
            }
        }
    }
}
