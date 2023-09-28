using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class BuildTower : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _tower;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _towerTile;
    [SerializeField] private Tile _buildEnable;
    [SerializeField] private GameObject _grid;
    [SerializeField] private Transform _parent;
    public static bool _buildingMode = false;

    void OnEnable()
    {
        _button.onClick.AddListener(SetMode);
    }

    void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SetMode()
    {
        if(_buildingMode == false)
        {
            _buildingMode = true;
            Time.timeScale = 0;
            _grid.SetActive(true); 
        }
        else
        {
            _buildingMode = false;
            Time.timeScale = 1;
            _grid.SetActive(false); 
        }
    }

    void Update()
    {
        if(_buildingMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetBuild();
            }
        }
    }

    private void SetBuild()
    {
        Vector3Int coordinate = _tilemap.WorldToCell(GetMousePosition());
        if(_tilemap.GetTile(coordinate) == _buildEnable)
        {
            _tilemap.SetTile(coordinate, _towerTile);
            GameObject tower = Instantiate(_tower, coordinate, Quaternion.identity);
            tower.transform.SetParent(_parent);
            _grid.SetActive(false);
            Time.timeScale = 1;
            _buildingMode = false;
        }
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
