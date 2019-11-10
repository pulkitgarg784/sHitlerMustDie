using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// Start is called before the first frame update
	private playerHealth playerHealth;

	void Start()
    {
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();

	}

	// Update is called once per frame
	void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerHealth.AddMoney(1);
			Debug.Log("Coin!!!!");
			Destroy(gameObject);

		}

	}
}
