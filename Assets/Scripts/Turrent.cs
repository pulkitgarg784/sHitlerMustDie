using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{

	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float bulletSpeed;
	public float bulletTimer;

	public bool awake = false;
	public bool lookingRight = false;

	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointL;
	public Transform shootpointR;

    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void Awake()
	{
		anim = transform.GetComponent<Animator>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update()
    {
		anim.SetBool("Awake", awake);
		anim.SetBool("LookRight", lookingRight);
		RangeCheck();


	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			awake = false;
			Debug.Log("Turrent Dies");
			transform.gameObject.SetActive(false);

		}
	
	}
	void RangeCheck()
	{
		distance = Vector3.Distance(transform.position, target.transform.position);
		if (distance < wakeRange)
		{
			awake = true;
		}
		else
		{
			awake = false;
		}
		if (target.transform.position.x > transform.position.x)
		{
			lookingRight = true;
		}
		if (target.transform.position.x < transform.position.x)
		{
			lookingRight = false;
		}
	}
	public void Attack(bool attackingRight)
	{
		bulletTimer += Time.deltaTime;
		if (bulletTimer >= shootInterval)
		{
			Vector2 dir = target.transform.position - transform.position;
			dir.Normalize();
			if (!attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootPointL.transform.position, shootPointL.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

				bulletTimer = 0;
			}
			if (attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

				bulletTimer = 0;
			}
		}
	}
}
