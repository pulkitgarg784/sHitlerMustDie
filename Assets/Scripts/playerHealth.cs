using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour
{
	public float health = 5;
	public float coins = 0;

	public Text healthtext;
	public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
		healthtext.text = "Health: " + health;
		coinText.text = "Coins: " + coins;

	}

	// Update is called once per frame
	void Update()
    {
        
    }
	void Die()
	{
		if (health==0)
		{
			Debug.Log("Died");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	public void DeductHealth(float dmg)
	{
		health -= dmg;
		gameObject.GetComponent<Animation>().Play("Damage");
		healthtext.text = "Health: " + health;
		//transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		//transform.position = new Vector3(0, 0, 0);

		Die();
	}
	public void AddMoney(float coin)
	{
		coins += coin;
		gameObject.GetComponent<Animation>().Play("CoinPick");
		coinText.text = "Coins: " + coins;
		//transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		//transform.position = new Vector3(0, 0, 0);

		Die();
	}
	public IEnumerator KnockBack(float knockDur,float knockBackPwr,Vector3 knockBackDir)
	{
		float timer = 0;
		transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x, 0);
		while (knockDur>timer)
		{
			timer += Time.deltaTime;
			transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(knockBackDir.x + 20, knockBackDir.y + knockBackPwr, transform.position.z));

		}
		yield return 0;
	}
}
