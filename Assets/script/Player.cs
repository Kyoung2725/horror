using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;


public class Player : MonoBehaviour {

	//newcode
	[SerializeField]float MaxHealth =100;
	[SerializeField]float Health;//players hitpoints
	[SerializeField]Image ImgHealth;//ref to hpbar sprite 
	[SerializeField]AudioSource myAudioSourse;//ref to AudioSource on player
	[SerializeField]AudioClip PlayerHurt;//ref to Audioclip played then player is hit
	[SerializeField]AudioClip sneak;//ref to Audioclip played then player is hit
	public bool isSneaking = false;



	//newcode
	// Use this for initialization
	void Start () {
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		ImgHealth.fillAmount=(float)Health/(float)MaxHealth;
		Hide ();
		if (Health <= 0) 
		{
			SceneManager.LoadScene("Dealth_Scene");
		}
	}

	public void Hide ()
	{
		if (CrossPlatformInputManager.GetButton ("Fire2")) 
		{
			isSneaking = true;
			myAudioSourse.clip = sneak;
			myAudioSourse.Play ();
		} 
		else
		{
			isSneaking = false;
		}

	}

	public void Damage(int dmg)
	{
		Health -= dmg;
		myAudioSourse.clip = PlayerHurt;
		myAudioSourse.Play ();
		if (Health <= 0) {
			SceneManager.LoadScene ("Dealth_Scene");
		} else 
		{
			myAudioSourse.clip = PlayerHurt;
			myAudioSourse.Play ();
		}
	}

}
