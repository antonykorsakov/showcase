using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    [Serializable]
    public class TileData
    {
        [SerializeField] private TetrominoType _type;
        [SerializeField] private Tile _gridCell;

        public TetrominoType Type => _type;
        public Tile GridCell => _gridCell;
        public TetrominoShape Shape => Constants.AllTetrominoShapes[_type]; 
    }
}