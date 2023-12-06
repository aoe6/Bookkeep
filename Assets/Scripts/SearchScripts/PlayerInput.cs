using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckForPrefab();
        }
    }

    void CheckForPrefab()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            
            Debug.Log("Found a prefab!");
            Destroy(hit.collider.gameObject);
            gameManager.PrefabFound();
        }
    }
}
