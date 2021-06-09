﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Serialization;

public class EnemyAI3D : MonoBehaviour
{
    [Header("Target")]
    public GameObject target; //Target object to move towards and attack.
    public TargetType targetType; //Type of target (player, enemy, etc).

    [Header("Distances")]
    public float
        attackDistance; //Distance from the target at which the enemy will attack them.

    [Header("Navigation")]
    public List<Vector3>
        path = new List<Vector3>(); //Navigation path to move along.

    private float
        pathUpdateRate =
            0.5f; //How often will the navigation path be updated?

    private float lastPathUpdateTime; //Last time the path was updated.

    [FormerlySerializedAs("enemy")] [Header("Components")] public Enemy3DShooter enemy3DShooter; //Enemy's enemy component.
    public Rigidbody rig; //Enemy's rigidbody component.
    public NavMeshAgent agent; //Enemy's NavMeshAgent component.

    //Private values
    private float lastAttackTime; //Last time the enemy attacked.

    void Start()
    {
        //Get missing components.
        if (!enemy3DShooter) enemy3DShooter = GetComponent<Enemy3DShooter>();
        if (!rig) rig = GetComponent<Rigidbody>();
        if (!agent) GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Return if we don't have a target or we're dead.
        if (!target || enemy3DShooter.state == EnemyState.Dead)
            return;

        //Check distance to target to change state.
        DistanceCheck();

        //Can we move? Then move.
        if (enemy3DShooter.canMove)
        {
            if (enemy3DShooter.state == EnemyState.Chasing)
            {
                Move();

                //Generate a path towards the target every 'pathUpdateRate' seconds.
                if (Time.time - lastPathUpdateTime > pathUpdateRate)
                {
                    lastPathUpdateTime = Time.time;
                    GenerateNewPath();
                }
            }
        }

        //Can we attack?
        if (enemy3DShooter.canAttack)
        {
            //Are we attacking?
            if (enemy3DShooter.state == EnemyState.Attacking)
            {
                //Do we have the correct time to attack?
                if (Time.time - lastAttackTime > enemy3DShooter.attackRate)
                {
                    lastAttackTime = Time.time;
                    AttackTarget();
                }
            }
        }
    }

    //Checks distance to target.
    void DistanceCheck()
    {
        //Calculate distance between enemy and target.
        float dist =
            Vector3.Distance(transform.position, target.transform.position);

        //Are we in the attack range? Then start attacking.
        if (dist <= attackDistance && enemy3DShooter.state != EnemyState.Attacking)
        {
            enemy3DShooter.state = EnemyState.Attacking;
            enemy3DShooter.anim.SetBool("Moving", false);
        }
        //Otherwise keep chasing the target.
        else if (dist > attackDistance && enemy3DShooter.state != EnemyState.Chasing)
        {
            enemy3DShooter.state = EnemyState.Chasing;
            enemy3DShooter.anim.SetBool("Moving", true);
        }
    }

    //Moves the enemy towards the target.
    void Move()
    {
        //Do we have a path we can follow?
        if (path.Count > 0)
        {
            //If we're right next to the path point, remove it.
            if (Vector3.Distance(transform.position, path[0]) < 1)
                path.RemoveAt(0);

            //No path yet? Return.
            if (path.Count == 0)
                return;

            //Set out target pos to be the closest path point.
            Vector3 targetPos = path[0];

            //If we only have 1 point in the path, just set the target pos to be the player.
            if (path.Count == 1)
                targetPos = target.transform.position;

            transform.position +=
                transform.forward * enemy3DShooter.moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(transform.rotation.x,
                    GetRotationToPosition(targetPos), transform.rotation.z),
                10 * Time.deltaTime);
        }
    }

    //Generates a new path from the enemy to the target by using NavMesh.
    void GenerateNewPath()
    {
        NavMeshPath navPath = new NavMeshPath();

        agent.enabled = true;
        agent.CalculatePath(target.transform.position, navPath);
        agent.enabled = false;

        path = navPath.corners.ToList();
    }

    //Deals damage to the target.
    void AttackTarget()
    {
        if (targetType == TargetType.Player)
            Player3DWaveShooter.inst.TakeDamage(enemy3DShooter.attackDamage);
        else if (targetType == TargetType.Enemy)
            target.GetComponent<Enemy3DShooter>().TakeDamage(enemy3DShooter.attackDamage);

        enemy3DShooter.anim.SetTrigger("Attack");
    }

    //Returns a direction between two points.
    public Vector3 GetDirection(Vector3 a, Vector3 b)
    {
        return (b - a).normalized;
    }

    //Returns an angle (y axis) from the enemy to a position.
    float GetRotationToPosition(Vector3 pos)
    {
        Vector3 dir = GetDirection(transform.position, pos);
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        return angle;
    }
}

public enum TargetType
{
    Player,
    Enemy
}