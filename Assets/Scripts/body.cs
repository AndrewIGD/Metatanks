using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour
{
    GameObject mainBody;
    [SerializeField] float hp;
    [SerializeField] float weight = 1f;
    [SerializeField] float kineticArmor;
    [SerializeField] float thermalArmor;
	[SerializeField] GameObject chestie;
	int coll = 0;
public float ReturnHp()
	{
		return hp;
	}
	public GameObject ReturnChestie()
	{
		return chestie;
	}
    public float ReturnWeight()
    {
        return weight;
    }
    public float ReturnThermalArmor()
    {
        return thermalArmor;
    }
    public float ReturnKineticArmor()
    {
        return kineticArmor;
    }
    // Start is called before the first frame update
    void Start()
    {
        TankBody[] body = FindObjectsOfType<TankBody>();
        foreach (TankBody i in body)
        {
            if (transform.IsChildOf(i.transform))
            {
                mainBody = i.gameObject;
                mainBody.GetComponent<TankBody>().GetHp(hp);
                mainBody.GetComponent<TankBody>().GetWeight(weight);
                mainBody.GetComponent<TankBody>().GetBody(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
