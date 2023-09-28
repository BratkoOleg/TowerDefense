using UnityEngine;
using UnityEngine.Tilemaps;

public class SetTilesAroundTower : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Tile _towerTile;
    [SerializeField] Tile _buildEnable;
    private Vector3Int[] _directions =  {Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right};

    void Awake()
    {
        _tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        SetTilesAround();
    }

    private void SetTilesAround()
    {
        for(int i = 0; i < _directions.Length; i++)
        {
            if(_tilemap.GetTile(_directions[i] + SetPosiotion()) != _towerTile)
            _tilemap.SetTile(_directions[i] + SetPosiotion(), _buildEnable);
        }
        Debug.Log(gameObject.name + " set around");
    }

    private Vector3Int SetPosiotion()
    {
        Vector3Int pos = _tilemap.WorldToCell(transform.position);
        return pos;
    }
}
