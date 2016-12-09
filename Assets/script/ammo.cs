using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ammo : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject Flaregun = GameObject.FindWithTag("Gun");
		flaregun Cgun = Flaregun.GetComponent<flaregun>();
		text.text = Cgun.currentRound + "/" + Cgun.spareRounds;
	
	}
}
