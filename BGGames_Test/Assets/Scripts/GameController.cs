using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Labirynth _labirynth;

        private LabirynthGenerator _labirinthGenerator;

        public Transform object1;
        public Transform object2;

        // Start is called before the first frame update
        void Start()
        {
            _labirinthGenerator = new LabirynthGenerator(_labirynth);
            _labirinthGenerator.GenerateLabirynth();

            object1.position = _labirynth.GetCellPosition((1, 1));
            object2.position = _labirynth.GetCellPosition((_labirynth.Settings.Size-2, _labirynth.Settings.Size -2));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}