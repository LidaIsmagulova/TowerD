 
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaycable;
    [SerializeField] private Tower tower;

    public bool IsPlaycable
    {
        get { return isPlaycable; }
    }
    private void OnMouseDown()
    {
        if (!isPlaycable)
            return;
        bool isPlaced = tower.CreateTower(tower, transform.position);
        isPlaycable = !isPlaced;
    }
}
