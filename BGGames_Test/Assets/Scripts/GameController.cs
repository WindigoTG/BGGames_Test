using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BGGames_Test
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Labirynth _labirynth;
        [SerializeField] private ShieldButton _shieldButton;
        [SerializeField] private Image _darkScreen;

        private LabirynthGenerator _labirinthGenerator;
        private PlayerController _playerController;

        private float _fadeCounter = 0;

        #endregion


        #region UnityMethods

        void Start()
        {
            _playerController = new PlayerController(_labirynth, _shieldButton);
            _labirinthGenerator = new LabirynthGenerator(_labirynth);

            _labirinthGenerator.GenerateLabirynth();
            _playerController.ResetPlayer();

            _playerController.Finished += Restart;

            StartCoroutine(StartingProcess());
        }

        void Update()
        {
            _playerController.RegularUpdate();
        }

        #endregion


        #region Methods

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
            yield return new WaitForSeconds(1f);

            while (_fadeCounter < 1)
            {
                _fadeCounter = Mathf.Min(_fadeCounter += Time.deltaTime, 1);
                var color = _darkScreen.color;
                color.a = _fadeCounter;
                _darkScreen.color = color;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(0.5f);

            _playerController.ResetPlayer();
            _labirinthGenerator.GenerateLabirynth();

            while (_fadeCounter > 0)
            {
                _fadeCounter = Mathf.Max(_fadeCounter -= Time.deltaTime, 0);
                var color = _darkScreen.color;
                color.a = _fadeCounter;
                _darkScreen.color = color;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(2f);
            _playerController.Start();
        }

        #endregion
    }
}