using System;
using UnityEngine;


namespace BGGames_Test
{
    [Serializable]
    public class LabirynthSettings
    {
        [SerializeField] private int _size;
        [SerializeField, Range(0.1f, 0.5f)] private float _emptySpaceTreshold = 0.1f;
        [SerializeField] float _corridorWidth = 1f;
        [SerializeField] float _wallHeight = 1f;
        [SerializeField] private Material _labirynthMaterial;
        [SerializeField, Min(0)] int _numberOfTraps;

        public int Size => _size;
        public float EmptySpaceTreshold => _emptySpaceTreshold;
        public float CorridorWidth => _corridorWidth;
        public float WallHeight => _wallHeight;
        public Material Material => _labirynthMaterial;
        public int NumberOfTraps => _numberOfTraps;
    }
}