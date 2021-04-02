using System;
using Assets.Scripts;
using Panda;
using UnityEngine;
using UnityEngine.AI;

namespace Magician.Golem
{
    public class GolemAI : MonoBehaviour
    {
        [SerializeField]
        private Unit _unit;

        private NavMeshAgent _agent;
        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag(GlobalConstants.PLAYER_TAG);
            _agent = GetComponent<NavMeshAgent>();
        }
        
        [Task]
        private void GetRunBackPoint()
        {
            _unit.SetColor(Color.green);

            _unit.ChangePointMovement(_player.transform.position);

            Task.current.Succeed();
        }
        
        [Task]
        private void Attack()
        {
            _unit.SetColor(Color.red);
            Task.current.Succeed();
        }
    }
}
