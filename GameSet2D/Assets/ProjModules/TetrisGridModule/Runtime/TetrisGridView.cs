using UnityEngine;
using UnityEngine.Tilemaps;

namespace ProjModules.TetrisGridModule.Runtime.Data
{
    public class TetrisGridView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;

        public Tilemap Tilemap => _tilemap;
    }
}