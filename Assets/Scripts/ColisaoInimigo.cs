using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisaoInimigo : MonoBehaviour
{
    public int vida = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        morrer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goblin"))
        {
            // Reduza a vida do personagem
            vida -= 10; // Exemplo: reduz 10 de vida ao colidir com o monstro
            Debug.Log($"Personagem sofreu dano! Vida restante: {vida}");
        }
    }

    void morrer (){
        if(vida == 0){
            Destroy(gameObject);
        }
    }
}
