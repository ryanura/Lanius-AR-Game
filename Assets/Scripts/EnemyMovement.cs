using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour {
	private GameObject target;
	NavMeshAgent navMeshAgent;

	//private int wavepointIndex = 0;
	private Enemy enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy>();
		target = GameObject.FindGameObjectWithTag("Player");
		navMeshAgent = 	GetComponent<NavMeshAgent>();

		navMeshAgent.speed = enemy.Speed;

		if (target)
		{
			navMeshAgent.destination = target.transform.position;
		}
	}

	public void UpdateEnemy()
	{
		navMeshAgent.speed = enemy.Speed;
	} 

	public void StopNavMesh(){
		navMeshAgent.isStopped = true;
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("Check Distance NavMesh then do Damage");
		if (other.gameObject.tag == "Player")
		{
			enemy.DoDamage();
			transform.LookAt(target.transform.position);
			navMeshAgent.updatePosition = false;
			navMeshAgent.updateRotation = false;
		}
	

		// if (other.gameObject.tag == "Player")
		// {
		// 	if (!navMeshAgent.pathPending){
		// 		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
		// 		{
		// 			if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
		// 			{
						
		// 				
		// 			}
		// 		}
		// 	}
		// }
	}
	
}