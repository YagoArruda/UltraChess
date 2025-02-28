using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public int movimentos_feitos = 0;
    public Coordenada posicao_atual;
    [SerializeField]
    private List<Coordenada> movimentos = new List<Coordenada>();

    public bool selecionado = false;
    public float tamanho = 1;

    private GameObject controlador;

    void Start()
    {
        controlador = GameObject.FindGameObjectWithTag("GameController");
        posicao_atual = new Coordenada();
        posicao_atual.linha = 6;
        posicao_atual.coluna = 2;

        controlador.transform.GetComponent<Controlador>().ativar_ladrilho(posicao_atual.linha,posicao_atual.coluna);
    }

    void Update()
    {

        if(selecionado == true)
        {

            this.transform.GetChild(0).localScale = new Vector3(tamanho, tamanho, tamanho);
        }
        else
        {

            this.transform.GetChild(0).localScale = new Vector3(1,1,1);
        }
    }
}

[Serializable]
public class Coordenada
{
    public int linha;
    public int coluna;
}
