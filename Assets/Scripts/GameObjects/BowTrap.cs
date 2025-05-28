using UnityEngine;

public class BowTrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject arrowPrefab;
    public Transform firePoint;
    public Vector2 direction = Vector2.up;

    public void FireArrow() // цей метод викликається з анімації
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Fire(direction);
    }
}
