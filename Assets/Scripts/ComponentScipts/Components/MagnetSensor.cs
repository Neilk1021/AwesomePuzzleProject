using UnityEngine;

public class MagnetSensor : MonoBehaviour
{
    private Magnet _magnet;

    public void Initialize(Magnet magnet)
    {
        _magnet = magnet;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Sensor triggered by: {other.gameObject.name} on layer: {LayerMask.LayerToName(other.gameObject.layer)}");
        if (other.TryGetComponent<Crate>(out var crate))
            _magnet.OnCrateEnter(crate);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Crate>(out var crate))
            _magnet.OnCrateExit(crate);
    }

}
