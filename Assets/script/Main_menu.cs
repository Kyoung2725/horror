using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour {

	public void PlayButton_use()
	{
		SceneManager.LoadScene("Story_menu");
	}
	public void ExitButton_use()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying=false;
#else
		Application.Quit();
#endif
	}
}
