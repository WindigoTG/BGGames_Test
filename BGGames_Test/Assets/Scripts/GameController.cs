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

        // Start is called before the first frame update
        void Start()
        {
            _playerController = new PlayerController(_labirynth);
            _labirinthGenerator = new LabirynthGenerator(_labirynth);

            _labirinthGenerator.GenerateLabirynth();
            _playerController.ResetPlayer();

            _playerController.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}