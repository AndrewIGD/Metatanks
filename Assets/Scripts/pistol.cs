using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] float atkSpeed = 1f;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] GameObject bulletPos;
    [SerializeField] GameObject bulletPos2;
    [SerializeField] GameObject ogPos;
    [SerializeField] AudioClip shot;
    [SerializeField] float weight = 1f;
    [SerializeField] float hp;
	[SerializeField] int effect = 0;
	[SerializeField] GameObject holderr;
    GameObject mainPistol;
    // Start is called before the first frame update
	public GameObject ReturnHolder()
	{
		return holderr;
	}
	public float ReturnHp()
	{
		return hp;
	}
    public float ReturnDmg()
    {
        return damage;
    }
    public float ReturnAtkSpeed()
    {
        return atkSpeed;
    }
    public float ReturnBltSpeed()
    {
        return bulletSpeed;
    }
    public float ReturnWeight()
    {
        return weight;
    }
    void Start()
    {
        bltpos[] blt = FindObjectsOfType<bltpos>();
        foreach(bltpos i in blt)
        {
            if (i.gameObject.transform.IsChildOf(gameObject.transform))
            {
                bulletPos = i.gameObject;
            }
        }
        TankPistol[] pistoale = FindObjectsOfType<TankPistol>();
        foreach (TankPistol i in pistoale)
        {
            if (transform.IsChildOf(i.gameObject.transform))
            {
                mainPistol = i.gameObject;
                mainPistol.GetComponent<TankPistol>().GetDamage(damage);
                mainPistol.GetComponent<TankPistol>().GetAtkSpeed(atkSpeed);
                mainPistol.GetComponent<TankPistol>().GetBltSpeed(bulletSpeed);
                mainPistol.GetComponent<TankPistol>().GetBltPos(bulletPos);
                mainPistol.GetComponent<TankPistol>().GetPistol(gameObject);
                mainPistol.GetComponent<TankPistol>().GetShot(shot);
                mainPistol.GetComponent<TankPistol>().GetWeight(weight);
                mainPistol.GetComponent<TankPistol>().GetHp(hp);
            }
        }
    }
	public int ReturnEffect()
	{
		return effect;
	}
	public GameObject ReturnBltPos()
	{
		return bulletPos;
	}
    public GameObject ReturnBltTwo()
    {
        return bulletPos2;
    }
	public GameObject ReturnOgPos()
	{
		return ogPos;
	}
    // Update is called once per frame
    void Update()
    {

    }
}
