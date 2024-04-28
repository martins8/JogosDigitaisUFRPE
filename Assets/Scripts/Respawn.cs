using UnityEngine;

public class MonstroRespawn : MonoBehaviour
{

    public GameObject monstroPrefab; // Prefab do monstro
    public float intervaloRespawn = 5f; // Intervalo de respawn em segundos
    public Transform pontoDeRespawn; // Ponto de respawn (objeto vazio na cena)
    private float tempoUltimoRespawn;

    private void Start()
    {
        tempoUltimoRespawn = Time.time;
    }

    private void Update()
    {
        // Verifica se é hora de respawnar
        if (Time.time - tempoUltimoRespawn >= intervaloRespawn)
        {
            RespawnMonstro();
        }
    }

    private void RespawnMonstro()
    {
        // Cria um novo monstro a partir do prefab no ponto de respawn
        Instantiate(monstroPrefab, pontoDeRespawn.position, Quaternion.identity);


        // Atualiza o tempo do último respawn
        tempoUltimoRespawn = Time.time;
    }
}
