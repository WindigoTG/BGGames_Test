using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class PlayerController
    {
        private Player _player;
        private Labirynth _labirynth;

        public PlayerController(Labirynth labirynth)
        {
            _player = new Player();
            _labirynth = labirynth;
        }

        public void ResetPlayer()
        {
            _player.Hide();
            _player.SetPosition(_labirynth.GetCellPosition((1, 1)));
            _player.Show();
        }

        public void Start()
        {
            _player.StartMovingToPoint(_labirynth.GetCellPosition((_labirynth.Settings.Size - 2, _labirynth.Settings.Size - 2)));
        }
    }
}