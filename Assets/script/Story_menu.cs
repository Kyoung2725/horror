using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Story_menu : MonoBehaviour {

	public void NextButton_use()
	{
		SceneManager.LoadScene("Control_menu");
	}

}
