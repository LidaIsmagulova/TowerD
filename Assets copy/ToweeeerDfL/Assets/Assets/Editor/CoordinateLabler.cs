using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;

    TMP_Text _label;
    private Vector2Int _coordinates;
    private Waypoint _waypoint;
    private void Awake()
    {
        _waypoint = GetComponentInParent<Waypoint>();
        _label = GetComponent<TMP_Text>();
        DisplayCoordinates();
    }
    private void Update()
    {
        ToggleLabels();
        ColorCoordinates();
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
        _label.color = _waypoint.IsPlaycable ? defaultColor : blockedColor;
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
