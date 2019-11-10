using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private playerHealth playerHealth;

	// Start is called before the first frame update
	void Start()
    {
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
		Destroy(gameObject,5f);

	}

	// Update is called once per frame
	void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerHealth.DeductHealth(1);
			Destroy(gameObject);
			//StartCoroutine(playerHealth.KnockBack(.2f, 120, playerHealth.transform.position));

		}
		
	}
}
