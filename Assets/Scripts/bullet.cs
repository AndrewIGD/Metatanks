using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float damage;
	[SerializeField] int effect;
	[SerializeField] AudioClip smlcannon;
	[SerializeField] GameObject smlcannonvfx;
    [SerializeField] AudioClip mortar;
    [SerializeField] GameObject mortarvfx;
    [SerializeField] AudioClip flame;
    [SerializeField] GameObject flamevfx;
    GameObject initialTank;
    bool alreadyDid = false;
    [SerializeField] string damageType;
    public void GetTank(GameObject initTank)
    {
        initialTank = initTank;
    }
    public void GetDamage(float dmg)
    {
        damage = dmg;
    }
    public float ReturnDamage()
    {
        return damage;
    }
	public void GetEffect(int vfx)
	{
		effect = vfx;
	}
    public string ReturnDamageType()
    {
        return damageType;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<bullet>().enabled == true)
        {
            if ((collision.gameObject.tag == "TankBodyPart" ||
              collision.gameObject.tag == "F" ||
              (collision.gameObject.tag == "ground"
              && collision.gameObject.GetComponent<OgTank>() != null))
              && collision.gameObject != initialTank &&
              !collision.gameObject.transform.IsChildOf(initialTank.transform)
              && alreadyDid == false)
            {
				if (effect == 3)
					collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().DecreaseHp(damage, true, damageType, gameObject);
				else
					collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().DecreaseHp(damage, false, damageType, gameObject);
                if (effect == 3)
                {
                    if (collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().ReturnBurn() == 0)
                    {
                        AudioSource.PlayClipAtPoint(flame, Camera.main.transform.position, 1f);
                        GameObject clone = Instantiate(flamevfx);
                        clone.transform.position = new Vector3(collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().transform.position.x, collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().transform.position.y, 5f);
                        clone.transform.SetParent(collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().transform);
                        collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().SetBurn(clone);
                    }
                    collision.gameObject.GetComponent<OgTank>().ReturnTank().GetComponent<tank>().Burn();
                }
            }
            if (collision.gameObject != initialTank && !collision.gameObject.transform.IsChildOf(initialTank.transform) && collision.gameObject.tag != "bullet" && collision.gameObject.tag != "ceiling" && collision.gameObject.tag != "border")
            {
                if (alreadyDid == false)
                {
                    if (effect == 1)
                    {
                        AudioSource.PlayClipAtPoint(smlcannon, Camera.main.transform.position, 1f);
                        GameObject clone = Instantiate(smlcannonvfx);
                        clone.transform.position = transform.position;
                        Destroy(clone, 3f);
                    }
                    else if (effect == 2)
                    {
                        AudioSource.PlayClipAtPoint(mortar, Camera.main.transform.position, 1f);
                        GameObject clone = Instantiate(mortarvfx);
                        clone.transform.position = transform.position;
                        Destroy(clone, 3f);
                    }
                    alreadyDid = true;
                    Destroy(gameObject);
                }
            }
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
