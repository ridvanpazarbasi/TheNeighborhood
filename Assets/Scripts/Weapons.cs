using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public bool isGunShoot;
    private float gunShootFrequency;
    public float gunShootFrequencySet;
    public float range;
    public Camera myCamera;
    public ParticleSystem shootEffect;
    public ParticleSystem bulletTrack;
    public ParticleSystem bloodEffect;
    public List<GameObject> particleSyt;

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse0) || !isGunShoot || !(Time.time > gunShootFrequency)) return;
        GunShoot();
        gunShootFrequency = Time.time + gunShootFrequencySet;
    }

    private void GunShoot()
    {
        SoundsManager.Instance.SoundPlay(SoundsType.HandGun);
        shootEffect.Play();
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out var hit, range))
        {
            Debug.Log(hit.transform.name);
        }

        ParticleSystem obj;
        if (hit.transform.gameObject.CompareTag("Enemy"))
        {
            obj = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else if (hit.transform.gameObject.CompareTag($"Overturn"))
        {
            Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
            rg.AddForce(-hit.normal * 500f);
            obj = Instantiate(bulletTrack, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
        {
            obj = Instantiate(bulletTrack, hit.point, Quaternion.LookRotation(hit.normal));
        }

        particleSyt.Add(obj.gameObject);
        if (particleSyt.Count != 20) return;
        foreach (var t in particleSyt)
        {
            Destroy(t);
        }

        particleSyt.Clear();
    }
}