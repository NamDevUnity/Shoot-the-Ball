using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float m_moveSpees;
    [SerializeField] private LayerMask m_damageTo;
    private int damage;
    private Vector2 m_lastPos;
    private RaycastHit2D m_raycastHit;

    public int Damage { get => damage; set => damage = value; }

    private void OnEnable()
    {
        RefreshLastPos();
    }
    private void Update()
    {
        Move();
        RefreshLastPos();
    }

    private void FixedUpdate()
    {
        DealDamage();
    }

    private void DealDamage()
    {
        Vector2 rayDirection = (Vector2)transform.position - m_lastPos;
        float rayDistance = rayDirection.magnitude;
        rayDistance = Mathf.Clamp(rayDistance, 0f, 0.1f);
        m_raycastHit = Physics2D.Raycast(m_lastPos, rayDirection, rayDistance, m_damageTo);
        var collide = m_raycastHit.collider;
        if (!m_raycastHit || collide == null)
        {
            return;
        }
        DealDamageToBall();

    }

    private void DealDamageToBall()
    {
        gameObject.SetActive(false);
    }

    private void RefreshLastPos()
    {
        m_lastPos = transform.position;
    }

    private void Move()
    {
        transform.Translate(transform.right * m_moveSpees * Time.deltaTime, Space.World);
    }

    private void OnDisable()
    {
        m_raycastHit = new RaycastHit2D();
        transform.position = new Vector3(1000, 1000, 0f);

    }
}
