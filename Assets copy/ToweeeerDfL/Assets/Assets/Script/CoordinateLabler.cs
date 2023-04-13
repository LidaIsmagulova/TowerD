using UnityEngine;
using UnityEditor;
using TMPro;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    [SerializeField] private Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = new Color(1f,0.5f,0f);

    TMP_Text _label;
    private Vector2Int _coordinates;
    private GridManager _gridManager;
    private void Awake()
    {
        _gridManager=FindObjectOfType<GridManager>();
        pathColor = new Color(1f, 0.5f, 0f);
        //_gridManager = GetComponent<GridManager>();
        _label = GetComponent<TMP_Text>();
        _label.enabled = true;
        DisplayCoordinates();
    }
    private void Update()
    {
        ColorCoordinates();
        ToggleLabels();
        if (Application.isPlaying)
            return;
        if (_label == null)
            _label = GetComponent<TMP_Text>();
        DisplayCoordinates();
        UpdateObjectName();

    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _label.enabled = !_label.enabled;
    }
    private void ColorCoordinates()
    {
        if (_gridManager == null)
            return;
        Node node = _gridManager.GetNode(_coordinates);

        if (node == null)
            return;

        if (!node.isWalkable)
            _label.color = blockedColor;
        else if (node.isPath)
            _label.color = pathColor;
        else if (node.isExplored)
            _label.color = exploredColor;
        else
            _label.color = defaultColor;
        //_label.color = _waypoint.IsPlaycable ? defaultColor : blockedColor;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }
    private void DisplayCoordinates()
    {
        var position = transform.parent.position;
        _coordinates.x = Mathf.RoundToInt(position.x/ EditorSnapSettings.move.x);
        _coordinates.y = Mathf.RoundToInt(position.z / EditorSnapSettings.move.z);

        _label.text = $"{_coordinates.x}. {_coordinates.y}";
    }

}
