using UnityEngine;
using System.Collections;

public class WanderEnemy : HunterEnemy {


	protected Collider[] _TheLostCollider;// 5 trasforms only
	[SerializeField]
	protected LayerMask theLostLayer;
	protected float lostRadius=9999;


	[SerializeField]
	protected Transform[] _Path;// 5 trasforms only

	protected int step = 0;

	// Use this for initialization
	void Start () {
		_damage = 5;
		_chaseRadius = 15;
		_attackRange = 4.0f;
		base.SetStartingReferences ();


	}
	
	// Update is called once per frame
	void Update () {
		hAnimator.SetBool ("isChaseing", true);
		_TheLostCollider = Physics.OverlapSphere (_hTransform.position, lostRadius, theLostLayer);
		Player lostcheck = _TheLostCollider[0].GetComponent<Player> ();
		base.search ();
		if (_hunting == true && lostcheck.isSneaking == false) 
		{
			base.Chase ();
		}
		else
		{
			_prey = null;
			WanderPath ();
		}
	}

	protected virtual void WanderPath()
	{					
			Transform steppoint = _Path [step];
			float distance = Vector3.Distance (steppoint.position, _hTransform.position);
			_hNavMeshAgent.SetDestination (steppoint.transform.position);
			hAnimator.SetBool ("isChaseing", true);
			if (distance <= 4.0f) 
			{
			step+=1;
			if (step > 4)
			{
				step = 0;
			}
			}
		}
}
