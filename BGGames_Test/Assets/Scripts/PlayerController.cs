using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class PlayerController : IUpdateableRegular
    {
        #region Fields

        private Player _player;
        private Labirynth _labirynth;
        private ShieldButton _shieldButton;

        public event Action Finished;

        bool _isActive;

        bool _isShielded;
        private const float SHIELD_TIME = 2.0f;
        private float _remainingShieldTime;

        bool _isDead;
        private const float RESPAWN_COOLDOWN = 1.0f;
        private float _currentRespawnCooldown;

        #endregion


        #region ClassLifeCycles

        public PlayerController(Labirynth labirynth, ShieldButton shieldButton)
        {
            var playerView = UnityEngine.Object.Instantiate(Resources.LoadAll<Player>("")[0].gameObject);
            _player = playerView.GetComponent<Player>();
            _player.HidePlayer();

            _player.Finished += Finish;
            _player.Damaged += GetDamage;

            _labirynth = labirynth;

            _shieldButton = shieldButton;

            _shieldButton.ButtonPressed += EnableShield;
            _shieldButton.ButtonReleased += DisableShield;
        }

        #endregion


        #region Methods

        public void RegularUpdate()
        {
            if (_isShielded)
            {
                if (_remainingShieldTime > 0)
                    _remainingShieldTime -= Time.deltaTime;
                else
                    DisableShield();
            }

            if (_isDead)
            {
                if (_currentRespawnCooldown > 0)
                    _currentRespawnCooldown -= Time.deltaTime;
                else
                {
                    ResetPlayer();
                    Start();
                }
            }
        }

        public void ResetPlayer()
        {
            _player.HidePlayer();
            _player.NavMeshAgent.Warp(_labirynth.GetCellPosition((1, 1)));
            _player.ShowPlayer();
            _isDead = false;
        }

        public void Start()
        {
            _player.NavMeshAgent.SetDestination(
                _labirynth.GetCellPosition((_labirynth.Settings.Size - 2, _labirynth.Settings.Size - 2)));
            _isActive = true;
        }

        private void Finish()
        {
            if (_isActive)
            {
                _isActive = false;
                _player.Celebrate();
                Finished?.Invoke();
            }
        }

        private void GetDamage()
        {
            if (_isActive && !_isShielded)
            {
                _isActive = false;
                _player.Death();
                _isDead = true;
                _currentRespawnCooldown = RESPAWN_COOLDOWN;
            }
        }

        private void EnableShield()
        {
            _isShielded = true;
            _remainingShieldTime = SHIELD_TIME;
            _player.SwitchColor(true);
        }

        private void DisableShield()
        {
            _isShielded = false;
            _player.SwitchColor(false);
        }

        #endregion
    }
}