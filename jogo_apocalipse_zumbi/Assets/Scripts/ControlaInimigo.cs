using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    private float velocidade = 4;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Quaternion novarotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novarotacao);

        if (distancia > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);
            
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }
    void AtacandoJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }

}
