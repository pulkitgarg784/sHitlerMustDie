using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	private Rigidbody2D rgbd;
	public float fallDelay;
	private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
		originalPos = transform.position;
		rgbd = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			StartCoroutine(Fall());

		}
	}
	IEnumerator Fall()
	{
		yield return new WaitForSeconds(fallDelay);
		rgbd.isKinematic =false;
		//transform.GetComponent<BoxCollider2D>().isTrigger = true;
		yield return 0;
		yield return new WaitForSeconds(2);

		StartCoroutine(Return());

	}
	IEnumerator Return()
	{
		transform.position = originalPos;

		rgbd.isKinematic = true;
		//transform.GetComponent<BoxCollider2D>().isTrigger = false;

		yield return 0;
	}
}
