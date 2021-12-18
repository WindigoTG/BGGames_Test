using UnityEngine;

namespace BGGames_Test
{
    public class LabirynthGenerator
    {
        private Labirynth _labirynth;
        private LabirynthDataGenerator _dataGenerator;

        private int[,] _labirynthData;
        private GameObject _wallPrefab;

        private static string WALL_PATH = "Wall";

        public LabirynthGenerator(Labirynth labirynth)
        {
            _labirynth = labirynth;

            _dataGenerator = new LabirynthDataGenerator(_labirynth.Settings);

            _wallPrefab = Resources.Load<GameObject>(WALL_PATH);
        }

        public void GenerateLabirynth()
        {
            _labirynthData = _dataGenerator.GenerateData();

            GenerateWalls();
        }

        private void GenerateWalls()
        {
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
        }
    }
}