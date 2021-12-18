using UnityEngine;

namespace BGGames_Test
{
    public class Labirynth : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LabirynthSettings _settings;

        private Grid _grid;

        #endregion


        #region Properties

        public LabirynthSettings Settings => _settings;

        #endregion


        #region UnityMethods

        void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        void Update()
        {

        }

        #endregion


        #region Methods

        public Vector3 GetCellPosition((int x, int z) cellIndex)
        {
            var position = new Vector3Int(cellIndex.x, (int)transform.position.y, cellIndex.z);

            return _grid.CellToWorld(position); 
        }

        #endregion
    }
}