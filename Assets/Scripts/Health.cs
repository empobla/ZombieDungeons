/*
Takes damage to the main player
Makes the player die when he runs our of health
	
Jorge Damián Palacios Hristova	
*/

using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField]
	private int startingHealth = 5;

	private int currentHealth;

	//Initializes the health 
	private void OnEnable()
	{
		currentHealth = startingHealth;
	}

	//This method helps to lower the score of the player 
	public void TakeDamage(int damageAmount)
	{
		currentHealth -= damageAmount;

		if (currentHealth <= 0)
			Die();
	}

	//This method makes the player die
	private void Die()
	{
		gameObject.SetActive(false);
	}
}