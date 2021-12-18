using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Labirynth _labirynth;

        private LabirynthGenerator _labirinthGenerator;
        private PlayerController _playerController;

        void Start()
        {
            _playerController = new PlayerController(_labirynth);
            _labirinthGenerator = new LabirynthGenerator(_labirynth);

            _labirinthGenerator.GenerateLabirynth();
            _playerController.ResetPlayer();

            _playerController.MovementIsOver += Restart;

            StartCoroutine(StartingProcess());
        }

        void Update()
        {

        }

        private void Restart()
        {
            StartCoroutine(RestartingProcess());
        }

        IEnumerator StartingProcess()
        {
            yield return new WaitForSeconds(2f);
            _playerController.Start();
        }

        IEnumerator RestartingProcess()
        {
            yield return new WaitForSeconds(0.5f);
            _playerController.ResetPlayer();
            _labirinthGenerator.GenerateLabirynth();
            yield return new WaitForSeconds(2f);
            _playerController.Start();
        }
    }
}