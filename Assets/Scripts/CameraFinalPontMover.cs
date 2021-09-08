using UnityEngine;

public class CameraFinalPontMover : MonoBehaviour
{
    [SerializeField] private Transform _fighters;

    private void Update()
    {
        transform.localPosition = new Vector3(_fighters.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}
