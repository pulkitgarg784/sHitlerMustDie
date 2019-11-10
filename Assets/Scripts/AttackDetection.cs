using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
	public Turrent turrent;
	public bool isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
		turrent = GetComponentInParent<Turrent>();
    }
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (isLeft)
			{
				turrent.Attack(false);
			}
			else
			{
				turrent.Attack(true);
			}
		}
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
