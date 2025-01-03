using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(TetrisGridConfig),
        menuName = "Configs/" + nameof(TetrisGridConfig), order = 'T')]
    public class TetrisGridConfig : ScriptableObject, ITetrisGridConfig
    {
        [SerializeField] private Tile _tmp;
        [SerializeField] private int _width = 10;
        [SerializeField] private int _height = 20;
        [SerializeField] private GridRenderer _view;
        [SerializeField] private TileData[] _shapes;

        public Tile Tmp => _tmp;
        public int Width => _width;
        public int Height => _height;
        public GridRenderer View => _view;

        public TileData GetTetrominoShape(TetrominoType type)
            => Array.Find(_shapes, item => item.Type == type);
    }
}