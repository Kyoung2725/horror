using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Backtostart : MonoBehaviour {

	public void ReturnButton_use()
	{
		SceneManager.LoadScene("Main_manu");
	}
}
