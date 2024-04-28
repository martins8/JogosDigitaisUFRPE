using UnityEngine;

public class MonstroMovimento : MonoBehaviour
{
    private Vector3 posicaoTeleporte = new Vector3(5f, -11f, 0f);
    public float velocidade = 2f; // Velocidade de movimento do monstro
    private Vector3 direcao = Vector3.right; // Direção inicial (para a direita)

    private void Update()
    {
        // Movimentação do monstro
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    public void Morrer()
    {
        transform.position = posicaoTeleporte;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jogador"))
        {
            Morrer();
        }
    }
}
