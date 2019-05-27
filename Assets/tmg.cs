using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tmg : MonoBehaviour
{
	[SerializeField] GameObject pistol1;
	[SerializeField] GameObject pistol2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OgTank",0.1f);
    }
	private void OgTank()
	{
		pistol1.GetComponent<OgTank>().GetOgTank(GetComponent<OgTank>().ReturnTank());
		pistol2.GetComponent<OgTank>().GetOgTank(GetComponent<OgTank>().ReturnTank());
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
