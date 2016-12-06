using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Contol_menu : MonoBehaviour {

	public void NextButton_use()
	{
		SceneManager.LoadScene("Main_gameplay2");
	}
}
