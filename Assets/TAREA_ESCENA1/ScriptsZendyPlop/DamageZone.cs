using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiEspacioDeNombres
{
    public interface IDamageble
    {
        void TakeDamage(int damage);
    }
}

public class DamageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var damageble = other.GetComponent<MiEspacioDeNombres.IDamageble>();

        if (damageble != null)
        {
            damageble.TakeDamage(1);
        }
    }
}
