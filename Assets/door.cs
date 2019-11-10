using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
	public int sceneIndex;
	// Start is called before the first frame update
	void Start()
	{
		transform.GetComponent<Animator>().enabled = false;


	}

	// Update is called once per frame
	void Update()
    {
        
    }
	public void ChangeScene()
	{
		SceneManager.LoadScene(sceneIndex);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			transform.GetComponent<Animator>().enabled = true;

		}

	}
}
