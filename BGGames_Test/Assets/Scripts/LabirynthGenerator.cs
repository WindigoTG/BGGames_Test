using UnityEngine;

namespace BGGames_Test
{
    public class LabirynthGenerator
    {
        #region Fields

        private Labirynth _labirynth;
        private LabirynthDataGenerator _dataGenerator;

        private int[,] _labirynthData;
        private GameObject _wallPrefab;
        private GameObject _trapPrefab;

        private GameObject _finish;
        private GameObject _walls;
        private GameObject[] _traps;

        private static string WALL_PATH = "Wall";
        private static string FINISH_PATH = "Finish";
        private static string TRAP_PATH = "Trap";

        #endregion


        #region ClassLifeCycles

        public LabirynthGenerator(Labirynth labirynth)
        {
            _labirynth = labirynth;

            _dataGenerator = new LabirynthDataGenerator(_labirynth.Settings);

            LoadPrefabs();
        }

        #endregion


        #region Methods

        private void LoadPrefabs()
        {
            _wallPrefab = Resources.Load<GameObject>(WALL_PATH);
            _finish = Object.Instantiate(Resources.Load<GameObject>(FINISH_PATH));

            _traps = new GameObject[_labirynth.Settings.NumberOfTraps];
            _trapPrefab = Resources.Load<GameObject>(TRAP_PATH);

            for (int i = 0; i < _labirynth.Settings.NumberOfTraps; i++)
                _traps[i] = Object.Instantiate(_trapPrefab);
        }

        public void GenerateLabirynth()
        {
            _labirynthData = _dataGenerator.GenerateData();

            GenerateWalls();

            PlaceTraps();

            _finish.transform.position = _labirynth.GetCellPosition((_labirynth.Settings.Size - 2, _labirynth.Settings.Size - 2));
        }

        private void GenerateWalls()
        {
            if (_walls)
                Object.Destroy(_walls);

            GameObject go = new GameObject("LabirinthWalls");
            go.transform.position = Vector3.zero;

            for (int i = 0; i < _labirynth.Settings.Size; i++)
            {
                for (int j = 0; j < _labirynth.Settings.Size; j++)
                {
                    if (_labirynthData[i,j] == 1)
                    {
                        GameObject wall = Object.Instantiate(_wallPrefab);

                        wall.transform.position = _labirynth.GetCellPosition((i, j));

                        wall.transform.SetParent(go.transform);
                    }
                }
            }

            go.transform.SetParent(_labirynth.transform);

            _walls = go;
        }

        private void PlaceTraps()
        {
            for (int i = 0; i < _labirynth.Settings.NumberOfTraps; i++)
            {
                (int x, int z) position;

                do
                {
                    position.x = Random.Range(1, _labirynth.Settings.Size - 1);
                    position.z = Random.Range(1, _labirynth.Settings.Size - 1);
                } while (_labirynthData[position.x, position.z] != 0 || position == (1,1) ||
                        position == (_labirynth.Settings.Size - 2, _labirynth.Settings.Size - 2));

                _traps[i].transform.position = _labirynth.GetCellPosition(position);
            }
        }

        #endregion
    }
}