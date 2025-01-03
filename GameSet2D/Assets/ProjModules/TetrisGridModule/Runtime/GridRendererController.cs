using ProjModules.TetrisGridModule.Runtime.Data;
using UnityEngine;
using UnityEngine.Tilemaps;
using UObject = UnityEngine.Object;

namespace ProjModules.TetrisGridModule.Runtime
{
    public class GridRendererController : IGridRendererController
    {
        private readonly ITetrisGridConfig _config;
        private GridRenderer _gridRenderer;

        public GridRendererController(ITetrisGridConfig config)
        {
            _config = config;
        }

        public void EnableRenderer()
        {
            if (_gridRenderer == null)
                _gridRenderer = UObject.Instantiate(_config.View);

            _gridRenderer.gameObject.SetActive(true);
        }

        public void SetCell(int x, int y, Tile gridCell)
        {
            var tilemap = _gridRenderer.Tilemap;
            tilemap.SetTile(new Vector3Int(x, y), gridCell);
        }
    }
}