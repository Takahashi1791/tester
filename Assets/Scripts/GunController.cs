using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public enum ShootMode { AUTO, SEMIAUTO }
    public bool shootEnabled = true;
    [SerializeField]
    ShootMode shootMode = ShootMode.AUTO;
    [SerializeField]
    int gunDamage = 1;
    [SerializeField]
    int maxAmmo = 1000;
    [SerializeField]
    float shootInterval = 0.15f;
    [SerializeField]
    float shootRange = 50;
    [SerializeField]
    Vector3 muzzleFlashScale;
    [SerializeField]
    GameObject muzzleFlashPrefab;
    [SerializeField]
    GameObject hitEffectPrefab;
    bool shooting = false;
    int ammo;
    GameObject muzzleFlash;
    GameObject hitEffect;
    public int Ammo
    {
        set
        {
            ammo = Mathf.Clamp(value, 0, maxAmmo);
        }
        get
        {
            return ammo;
        }
    }
    void Start()
    {
        InitGun();
    }
    void Update()
    {
        if (shootEnabled & ammo > 0 & GetInput())
        {
            StartCoroutine(Shoot());
        }
    }
    void InitGun()
    {
        Ammo = maxAmmo;
    }
    bool GetInput()
    {
        switch (shootMode)
        {
            case ShootMode.AUTO:
                return Input.GetMouseButton(0);
            case ShootMode.SEMIAUTO:
                return Input.GetMouseButtonDown(0);
        }
        return false;
    }
    IEnumerator Shoot()
    {
        if (!shooting)
        {
            shooting = true;
            //マズルフラッシュON
            if (muzzleFlashPrefab != null)
            {
                if (muzzleFlash != null)
                {
                    muzzleFlash.SetActive(true);
                }
                else
                {
                    muzzleFlash = Instantiate(muzzleFlashPrefab, transform.position, transform.rotation);
                    muzzleFlash.transform.SetParent(gameObject.transform);
                    muzzleFlash.transform.localScale = muzzleFlashScale;
                }
            }
            ShootRay();
            yield return new WaitForSeconds(shootInterval);
            //マズルフラッシュOFF
            if (muzzleFlash != null)
            {
                muzzleFlash.SetActive(false);
            }
            //ヒットエフェクトOFF
            if (hitEffect != null)
            {
                if (hitEffect.activeSelf)
                {
                    hitEffect.SetActive(false);
                }
            }
            shooting = false;
        }
        else
        {
            yield return null;
        }
    }
    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        //レイを飛ばして、ヒットしたオブジェクトの情報を得る
        if (Physics.Raycast(ray, out hit, shootRange))
        {
            // ヒットしたオブジェクトが敵であるかをチェック
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // 敵にダメージを与える
                enemyHealth.TakeDamage(gunDamage);
            }
            //ヒットエフェクトON
            if (hitEffectPrefab != null)
            {
                if (hitEffect != null)
                {
                    hitEffect.transform.position = hit.point;
                    hitEffect.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                    hitEffect.SetActive(true);
                }
                else
                {
                    hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);
                }
            }
            //★ここに敵へのダメージ処理などを追加
        }
        Ammo--;
    }
}