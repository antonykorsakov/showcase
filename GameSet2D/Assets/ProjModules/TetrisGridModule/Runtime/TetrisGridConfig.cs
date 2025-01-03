using UnityEngine;

namespace ProjModules.TetrisGridModule.Runtime
{
    [CreateAssetMenu(fileName = nameof(TetrisGridConfig),
        menuName = "Configs/" + nameof(TetrisGridConfig), order = 'T')]
    public class TetrisGridConfig : ScriptableObject, ITetrisGridConfig
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private int _spawnAreaHeight;

        public int Width => _width;
        public int Height => _height;
        public int SpawnAreaHeight => _spawnAreaHeight;
    }
}