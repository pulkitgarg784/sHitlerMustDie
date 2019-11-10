using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	private playerHealth playerHealth;
    // Start is called before the first frame update
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
			playerHealth.DeductHealth(1);
			StartCoroutine(playerHealth.KnockBack(.2f, 80, playerHealth.transform.position));

		}

	}

}
