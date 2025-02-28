using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField]
    private GameObject peca_selecionada = null;
    [SerializeField]
    private float tamanho_peca_selecionada = 1.1f;


    [SerializeField]
    public int[,] referencia_tabuleiro = new int[8,8];

    [SerializeField]
    public List<GameObject> ladrilhos = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                referencia_tabuleiro[i, j] = -1;
            }
        }

    }

    void Update()
    {
        clicar_com_mouse();
    }

    private void clicar_com_mouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);


            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name);

                if (peca_selecionada == null)
                {
                    if (hit.transform.tag == "Peça")
                    {
                        peca_selecionada = hit.collider.gameObject;
                        float tamanho_alterado = tamanho_peca_selecionada;
                        peca_selecionada.transform.GetComponent<Movimento>().tamanho = tamanho_alterado;
                        peca_selecionada.transform.GetComponent<Movimento>().selecionado = true;
                    }
                }
                else
                {
                    peca_selecionada.transform.position = hit.collider.transform.localPosition;
                    peca_selecionada.transform.GetComponent<Movimento>().selecionado = false;
                    if (hit.transform.tag != "Peça")
                    {
                        peca_selecionada.transform.GetComponent<Movimento>().movimentos_feitos++;
                    }
                    peca_selecionada = null;
                }
            }
            else
            {
                if (peca_selecionada != null)
                {
                    peca_selecionada.transform.GetComponent<Movimento>().selecionado = false;
                }
                peca_selecionada = null;
            }
        }
    }

    public void ativar_ladrilho(int pos_x, int pos_y)
    {
        ladrilhos[(8*8)-1].SetActive(true);
        Debug.Log(pos_x +" / " + pos_y + " /// " + pos_x + 1 * pos_y + 1);
    }
}
