using UnityEngine;

public class ForbidenArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
            food.gameObject.SetActive(false);
    }
}
