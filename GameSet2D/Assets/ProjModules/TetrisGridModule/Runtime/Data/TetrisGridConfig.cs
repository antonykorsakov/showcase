using System;
using UnityEngine;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    [CreateAssetMenu(fileName = nameof(TetrisGridConfig),
        menuName = "Configs/" + nameof(TetrisGridConfig), order = 'T')]
    public class TetrisGridConfig : ScriptableObject, ITetrisGridConfig
    {
        [SerializeField] private int _width = 10;
        [SerializeField] private int _height = 20;
        [SerializeField] private TetrisGridView _view;
        [SerializeField] private TileData[] _shapes;

        public int Width => _width;
        public int Height => _height;
        public TetrisGridView View => _view;

        public TileData GetTetrominoShape(TetrominoType type)
            => Array.Find(_shapes, item => item.Type == type);
    }
}