using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Fighter fighter))
        {
            gameObject.SetActive(false);
        }
    }
}
