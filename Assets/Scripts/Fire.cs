using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    private Transform gun;
    public GameObject bulletPrefab;
    public float shotSpread = 10.0f;
    private PlayerInput m_CloneInput;
    private InputAction m_FireAction;
    private float cooldown;
    public int PlayerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<Transform>();
        m_CloneInput = GetComponent<PlayerInput>();
        m_FireAction = m_CloneInput.actions["Fire"];
        cooldown = 0;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(m_FireAction.ReadValue<float>().Equals(1) && cooldown <= 0)
        {
            float shotVariance = Random.Range(-90 - shotSpread, -90 + shotSpread);
            Vector3 shotPosition = gun.position + 0.25f * gun.right;
            GameObject bullet = Instantiate(bulletPrefab, shotPosition, (gun.rotation * Quaternion.Euler(0, 0, shotVariance)));
            cooldown = 0.4f;
        }

    }
}
