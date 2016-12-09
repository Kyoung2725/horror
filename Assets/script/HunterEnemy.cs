using UnityEngine;
using System.Collections;

public class HunterEnemy : MonoBehaviour {

	protected Transform _hTransform;
	protected NavMeshAgent _hNavMeshAgent;
	protected Collider[] _fHitColiders;
	protected Collider[] _pHitColiders;
	protected float _checkRate;
	protected float _nextCheck;
	protected float _chaseRadius;
	protected float _attackRadius;
	protected int _state = 0;
	[SerializeField]
	protected int _damage;
	protected float _attackTime;
	protected Transform _prey;
	protected bool _hunting = false;
	protected bool _canAttack = false;
	protected float _attackRange = 10.0f;

	[SerializeField]
	protected Animator hAnimator;
	[SerializeField]
	protected AudioSource hAudioSource;
	[SerializeField]
	protected LayerMask _pdetectionLayer;
	[SerializeField]
	protected LayerMask _fdetectionLayer;




	// Use this for initialization
	void Start () 
	{		
		_attackTime = 1.5f;
		_chaseRadius = 9999;
		SetStartingReferences ();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		search ();
		if (_hunting == true) 
		{
			Chase ();
		}
	}

	protected virtual void SetStartingReferences()
	{
		_hTransform = transform;
		_hNavMeshAgent = GetComponent<NavMeshAgent> ();
		_checkRate = Random.Range (0.9f, 1.3F);
	}

	protected virtual void Chase()
	{
		if (_prey!=null)
		{
		float distance = Vector3.Distance (_prey.position, _hTransform.position);
			if (distance > _attackRange) {
			hAnimator.SetBool ("isChaseing", true);
		} 
		else 
		{
			hAnimator.SetBool ("isChaseing", false);
			if (_canAttack == true) 
			{			
			Attack ();
			}
		}
			
		}
	}

	protected virtual void search ()
	{
		//check if time has passed and navmesh is enabeld 
		if (Time.time > _nextCheck && _hNavMeshAgent.enabled == true) 
		{
			_nextCheck = Time.time + _checkRate;
			//create a search sphere 
			_pHitColiders = Physics.OverlapSphere (_hTransform.position,_chaseRadius,_pdetectionLayer);
			_fHitColiders = Physics.OverlapSphere (_hTransform.position, _chaseRadius, _fdetectionLayer);
			if (_fHitColiders.Length > 0) {
				//move to location of flare
				_hNavMeshAgent.SetDestination (_fHitColiders [0].transform.position);
				_prey = _fHitColiders [0].transform;
				_hunting = true;
				_canAttack = false;
			} 
			else 
			{
				if (_pHitColiders.Length > 0) 
				{
					_hNavMeshAgent.SetDestination (_pHitColiders [0].transform.position);
					_prey = _pHitColiders [0].transform;
					_hunting = true;
					_canAttack = true;
				}
				else 
				{		
					_hunting = false;
					_canAttack = false;
					_prey = null;
				}
			}				
		}
	}
	protected virtual void Attack ()
	{
		_attackTime -= Time.deltaTime;
		if (_attackTime <= 0) 
		{						
			Player target = _prey.GetComponent<Player> ();
			hAnimator.SetBool ("isAttacking", true);
			target.Damage (_damage);
			_attackTime = 1.5f;
		}
		else
		{
			hAnimator.SetBool ("isAttacking", false);
		}
			
	}


}
