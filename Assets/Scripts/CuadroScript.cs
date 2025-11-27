using UnityEngine;

/// <summary>
/// Simple script: adjuntarlo al trigger en el piso (Collider con IsTrigger = true).
/// Cuando el jugador entra, aplica una fuerza tipo Impulse a un Rigidbody objetivo
/// para que salga despedido desde la pared (la dirección se calcula usando la posición de la pared).
/// Diseñado para Unity 2018; código lo más simple posible.
/// </summary>
public class CuadroScript : MonoBehaviour
{
    [Tooltip("Rigidbody del objeto que quieres lanzar.")]
    public Rigidbody target;
    [Tooltip("Transform de la pared (usado como origen para calcular la dirección hacia afuera).")]
    public Transform wall;
    [Tooltip("Magnitud de la fuerza (Impulse).")]
    public float force = 8f;
    [Tooltip("Componente vertical añadida a la dirección.")]
    public string playerTag = "Player";
    [Tooltip("Si true, solo se activa una vez.")]
    public bool oneShot = true;
    bool triggered = false;
    public bool derechaOIzquierda = true;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }
        if (triggered == true)
        {
            return;
        }
        else if (derechaOIzquierda == true)
        {
            // dirección desde la pared hacia el objeto
            Vector3 dir = (target.position - wall.position).normalized;
            if (dir.sqrMagnitude < 0.0001f) dir = wall.forward;

            Vector3 finalDir = (dir + Vector3.forward).normalized;

            // aplica la fuerza como en tu snippet original
            target.AddForce(finalDir * force, ForceMode.Impulse);

            triggered = true;
        }
        else
        {
            // dirección desde la pared hacia el objeto
            Vector3 dir = (target.position - wall.position).normalized;
            if (dir.sqrMagnitude < 0.0001f) dir = wall.forward;

            Vector3 finalDir = (dir + Vector3.back).normalized;

            // aplica la fuerza como en tu snippet original
            target.AddForce(finalDir * force, ForceMode.Impulse);

            triggered = true;
        }
    }
}