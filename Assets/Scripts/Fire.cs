using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    public GameObject gun;
    public GameObject bulletPrefab;
    public float shotSpread = 10.0f;
    public PlayerInput m_CloneInput;
    private InputAction m_FireAction;
    private float cooldown;
    public int PlayerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        m_FireAction = m_CloneInput.actions["Fire"];
        cooldown = 0;
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if(m_FireAction.ReadValue<float>().Equals(1) && cooldown <= 0)
        {
            float shotVariance = Random.Range(shotSpread, shotSpread);
            Vector3 shotPosition = gun.transform.position + 0.25f * gun.transform.right;
            GameObject bullet = Instantiate(bulletPrefab, shotPosition, (gun.transform.rotation * Quaternion.Euler(0, 0, shotVariance)));
            cooldown = 0.4f;
        }

    }
}
