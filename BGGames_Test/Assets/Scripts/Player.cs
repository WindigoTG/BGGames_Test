using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace BGGames_Test
{
    public class Player : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _playerObject;
        [SerializeField] private ParticleSystem _explosion;
        [SerializeField] private ParticleSystem _confetti;
        [SerializeField] private Color _regularColor;
        [SerializeField] private Color _invincibleColor;

        private NavMeshAgent _navMeshAgent;
        private MeshRenderer _meshRenderer;

        public event Action Finished;
        public event Action Damaged;

        #endregion


        #region Properties

        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        #endregion


        #region UnityMethods

        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        #endregion


        #region Methods

        public void ShowPlayer()
        {
            _playerObject.SetActive(true); 
        }

        public void HidePlayer()
        {
            _navMeshAgent.ResetPath();
            _playerObject.SetActive(false);
            _explosion.gameObject.SetActive(false);
            _confetti.gameObject.SetActive(false);
        }

        public void Celebrate()
        {
            _confetti.gameObject.SetActive(true);
            _confetti.Play();
        }

        public void Death()
        {
            _playerObject.SetActive(false);
            _explosion.gameObject.SetActive(true);
            _explosion.Play();
        }

        public void TriggerFinish()
        {
            Finished?.Invoke();
        }

        public void GetDamaged()
        {
            Damaged?.Invoke();
        }

        public void SwitchColor(bool isInvincible)
        {
            if (isInvincible)
                _meshRenderer.material.color = _invincibleColor;
            else
                _meshRenderer.material.color = _regularColor;
        }

        #endregion
    }
}