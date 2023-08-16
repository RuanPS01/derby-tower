using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDashSkillController : MonoBehaviour {
    public float dashForce = 500f; // Força do dash
    public float dashDuration = 0.2f; // Duração do dash

    public List<GameObject> leftParcicleObjects; // Particulas de efeito para o dash a esquerda
    public List<GameObject> rightParcicleObjects; // Particulas de efeito para o dash a esquerda

    private Rigidbody rb;
    private bool isDashing = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        // Verifica se a tecla E está pressionada para fazer o dash para a esquerda local
        if(Input.GetKeyDown(KeyCode.E) && !isDashing) {
            StartCoroutine(PerformDash(transform.right, leftParcicleObjects));
        }

        // Verifica se a tecla Q está pressionada para fazer o dash para a direita local
        if(Input.GetKeyDown(KeyCode.Q) && !isDashing) {
            StartCoroutine(PerformDash(-transform.right, rightParcicleObjects));
        }
    }

    IEnumerator PerformDash(Vector3 direction, List<GameObject> particlesObjects) {
        isDashing = true;

        foreach(GameObject particleObject in particlesObjects) {
            particleObject.SetActive(true);
        }

        Vector3 originalVelocity = rb.velocity;

        rb.velocity = direction * (originalVelocity.magnitude + dashForce); // Aplica a força do dash sem interromper a velocidade

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = originalVelocity; // Restaura a velocidade após o dash
        isDashing = false;

        foreach(GameObject particleObject in particlesObjects) {
            particleObject.SetActive(false);
        }
    }
}
