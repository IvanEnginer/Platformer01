using UnityEngine;

public class DeleterCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            Destroy(gameObject);
        }
    }
}
