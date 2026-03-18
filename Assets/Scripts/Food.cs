using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void RandomizePosition()
    {
        // Calculate the playable area inside the walls
        int xMin = (int)gridArea.bounds.min.x + 1; // +1 to avoid left wall
        int xMax = (int)gridArea.bounds.max.x - 2; // -2 to avoid right wall
        int yMin = (int)gridArea.bounds.min.y + 1; // +1 to avoid bottom wall
        int yMax = (int)gridArea.bounds.max.y - 2; // -2 to avoid top wall

        // Choose a random integer position inside the safe area
        int x = Random.Range(xMin, xMax + 1); // max exclusive
        int y = Random.Range(yMin, yMax + 1);

        this.transform.position = new Vector3(x, y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(10);
            RandomizePosition();
        }
    }
}
