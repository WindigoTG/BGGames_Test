using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGGames_Test
{
    public class Labirynth : MonoBehaviour
    {
        [SerializeField] private LabirynthSettings _settings;

        private Grid _grid;

        public LabirynthSettings Settings => _settings;

        void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;

            for (int x = 0; x < _settings.Size; ++x)
            {
                Gizmos.DrawLine(Vector3.right * x, Vector3.right * x + _settings.Size * Vector3.forward);
            }

            Gizmos.DrawLine(Vector3.right * _settings.Size, Vector3.right * _settings.Size + _settings.Size * Vector3.forward);

            for (int y = 0; y < _settings.Size; ++y)
            {
                Gizmos.DrawLine(Vector3.forward * y, Vector3.forward * y + Vector3.right * _settings.Size);
            }

            Gizmos.DrawLine(Vector3.forward * _settings.Size, Vector3.forward * _settings.Size + Vector3.right * _settings.Size);
        }

        public Vector3 GetCellPosition((int x, int z) cellIndex)
        {
            var position = new Vector3Int(cellIndex.x, (int)transform.position.y, cellIndex.z);

            return _grid.CellToWorld(position); 
        }
    }
}