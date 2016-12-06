using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadScene("Win_Scene");
	}
}
