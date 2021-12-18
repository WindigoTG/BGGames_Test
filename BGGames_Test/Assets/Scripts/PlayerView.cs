using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace BGGames_Test
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private ParticleSystem _explosion;
        [SerializeField] private ParticleSystem _confetti;

        private Rigidbody _rigidbody;
        private NavMeshAgent _navMeshAgent;

        public Transform Transform => transform;
        public Rigidbody RigidBody => _rigidbody;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

        }

        public void ShowPlayer()
        {
            _playerObject.SetActive(true); 
        }

        public void HidePlayer()
        {
            _playerObject.SetActive(false);
            _explosion.gameObject.SetActive(false);
            _confetti.gameObject.SetActive(false);
        }
    }
}