using UDEV.SPM;
using UnityEngine;
using UnityEngine.Events;

public class BarrelController : MonoBehaviour
{
    public BarrelData startData;
    [SerializeField] private Transform m_shottingPoint;
    [PoolerKeys(target = PoolerTarget.NONE)] 
    [SerializeField] private string m_bulletPoolKey;
    private float m_curFR;
    private bool m_isShootted;

    public UnityEvent OnShoot;

    private void Start()
    {
        LoadStart();
    }

    private void LoadStart()
    {
        if (startData == null) return;

        m_curFR = startData.firerate;
    }

    private void Update()
    {
        ReduceFirerate();
        Shoot();
    }

    public void Shoot()
    {
        if (m_isShootted || m_shottingPoint == null) return;
        m_isShootted = true;
        var bulletClone = PoolersManager.Ins.Spawn(PoolerTarget.NONE, m_bulletPoolKey, m_shottingPoint.position, Quaternion.identity);
        if (bulletClone == null) return;
        bulletClone.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        var projectComp = bulletClone.GetComponent<Projectile>();
        if (projectComp != null)
        {
            projectComp.Damage = startData.damage;
        }

        OnShoot?.Invoke();


    }

    private void ReduceFirerate()
    {
        if (!m_isShootted) return;
        m_curFR -= Time.deltaTime;

        if (m_curFR > 0) return;

        LoadStart();
        m_isShootted = false;

    }
}
