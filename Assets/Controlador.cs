using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField]
    private GameObject peca_selecionada = null;
    [SerializeField]
    private float tamanho_peca_selecionada = 1;

    void Start()
    {
        
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

            GameObject peca = get_peca_selecionada();

            if (hit.collider != null)
            {
                
                Debug.Log("Objeto clicado: " + hit.collider.gameObject.name);
                
                if (peca == null)// && hit.transform.tag == "Peça"
                {
                    peca = hit.collider.gameObject;

                    float tamanho_alterado = get_tamanho_peca_selecionada();
                    peca.transform.localScale = new Vector3(tamanho_alterado,tamanho_alterado,tamanho_alterado);
                }
                else
                {
                    peca.transform.position = hit.collider.transform.localPosition;
                    limpar_peca_selecionada();
                }
            }
            else
            {
                if (peca != null)
                {
                    peca.transform.localScale = new Vector3(1,1,1);
                }
                peca = null;
            }
        }
    }



    public GameObject get_peca_selecionada()
    {
        return peca_selecionada;
    }

    public void set_peca_selecionada(GameObject entrada)
    {
        peca_selecionada = entrada;
    }

    public void limpar_peca_selecionada()
    {
        if (get_peca_selecionada() != null)
        {
            get_peca_selecionada().transform.localScale = new Vector3(1,1,1);
        }
        set_peca_selecionada(null);
    }

    public float get_tamanho_peca_selecionada()
    {
        return tamanho_peca_selecionada;
    }

}
