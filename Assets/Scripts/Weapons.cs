using UnityEngine;

public class Weapons : MonoBehaviour
{
    public bool isGunShoot;
    private float gunShootFrequency;
    public float gunShootFrequencySet;
    public float range;
    public Camera myCamera;
    public ParticleSystem shootEffect;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isGunShoot && Time.time > gunShootFrequency)
        {
            GunShoot();
            gunShootFrequency = Time.time + gunShootFrequencySet;
        }
    }

    private void GunShoot()
    {
        RaycastHit hit;
        SoundsManager.Instance.SoundPlay(SoundsType.HandGun);
        shootEffect.Play();
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}