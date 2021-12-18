using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class PlayerController
    {
        private Player _player;
        private Labirynth _labirynth;

        public event Action MovementIsOver;

        bool _isActive;

        public PlayerController(Labirynth labirynth)
        {
            var playerView = UnityEngine.Object.Instantiate(Resources.LoadAll<Player>("")[0].gameObject);
            _player = playerView.GetComponent<Player>();
            _player.HidePlayer();

            _player.Finished += Finish;
            _player.Damaged += GetDamage;

            _labirynth = labirynth;
        }

        public void ResetPlayer()
        {
            _player.HidePlayer();
            _player.NavMeshAgent.Warp(_labirynth.GetCellPosition((1, 1)));
            _player.ShowPlayer();
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
                MovementIsOver?.Invoke();
            }
        }

        private void GetDamage()
        {
            if (_isActive)
            {
                _isActive = false;
                _player.Death();
                MovementIsOver?.Invoke();
            }
        }
    }
}