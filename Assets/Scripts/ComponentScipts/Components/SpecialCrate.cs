using UnityEngine;

public class SpecialCrate : MonoBehaviour
{
    [SerializeField] private float _attractSpeed = 5f;
    
    private Rigidbody2D _rigidbody;
    private Magnet _targetMagnet;
    private bool _isAttracted;

    private void Awake()
    {
        Debug.Log("I'm a crate");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMagnetActivate(Magnet magnet)
    {
        float dist = Vector2.Distance(transform.position, magnet.transform.position);
        if (dist > magnet.Data.Definition.magnetRange) return;

        if (_targetMagnet == null || dist < Vector2.Distance(transform.position, _targetMagnet.transform.position))
        {
            _targetMagnet = magnet;
            _isAttracted = true;
        }

        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void OnMagnetDeactivate(Magnet magnet)
    {
        if (_targetMagnet != magnet) return;
        _isAttracted = false;
        _targetMagnet = null;
        _rigidbody.velocity = Vector2.zero;
        
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void FixedUpdate()
    {
        if (!_isAttracted || _targetMagnet == null) return;
        MoveToAnchor();
    }

    private void MoveToAnchor()
    {
        Vector2 anchor = _targetMagnet.GetAnchorPoint();
        Vector2 toAnchor = anchor - (Vector2)transform.position;
        
        if (toAnchor.magnitude < 0.05f)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }
        
        Vector2 newPos = Vector2.MoveTowards(_rigidbody.position, anchor, Time.fixedDeltaTime * _attractSpeed);

        _rigidbody.MovePosition(newPos);
        _rigidbody.velocity = Vector2.zero;
    }
}