using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmigrantWaveLauncher : MonoBehaviour {

    /// <summary>
    /// Instancia um Ícone de Refugiados, com:
    ///     a) Número de Imigrantes; (semi randomizado com base em valores)
    ///     b) Ponto de instância
    ///     c) Ponto de chegada
    ///     d) Velocidade para chegar
    /// </summary>

    public int idDoProximoIcone = 0;

    public GameObject saida_refugiados_1, saida_refugiados_2;
    public GameObject entrada_refugiados_1, entrada_refugiados_2;

    void InstanciarIconeDeRefugiados(int quant_de_refugiados, GameObject saida, GameObject entrada, float tempo_em_segundos,
            float escala = 1.0f)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Onda De Imigrantes"));
        icone.transform.position = new Vector3(saida.transform.position.x,
                                               saida.transform.position.y,
                                               saida.transform.position.z);
        icone.GetComponent<ImmigrantWave>().numberOfImmigrants = quant_de_refugiados;
        icone.GetComponent<MovingToTheObjective>().objetivo_final = entrada.transform.position;
        icone.GetComponent<MovingToTheObjective>().tempo = tempo_em_segundos;
        icone.name = "Icone de Refugiados - ID " + idDoProximoIcone;
        if (escala > 1.0f)
        {
            icone.transform.localScale = new Vector3(icone.transform.localScale.x * escala,
                                                     icone.transform.localScale.y * escala,
                                                     1);
        }
        idDoProximoIcone++;
    }

    void InstanciaAleatoriaInstantaneaDeOnda()
    {
        int quant_de_refugiados;
        //Ano 1: de 50 a 150 refugiados por onda.
        //Ano 2: de 150 a 200 refugiados por onda.
        GameObject saida, entrada;
        float tempo_em_segundos;
        //Ano 1: de 30 a 60 segundos.
        //Ano 2: de 15 a 30 segundos.
        float escala = 1.0f;

        //Superonda: 750 a 1000 refugiados, de 150 a 300 segundos. Sprite 3x maior.

        if (TimeManager.instance.year == 1)
        {
            quant_de_refugiados = 50 + (int)(100 * Random.Range(0.0f, 1.0f));
            tempo_em_segundos = 30 + 30 * Random.Range(0.0f, 1.0f);
        }
        else if (Random.Range(0.0f, 1.0f) < 0.05f)
        {
            quant_de_refugiados = 750 + (int)(250 * Random.Range(0.0f, 1.0f));
            tempo_em_segundos = 150 + (int)(150 * Random.Range(0.0f, 1.0f));
            escala *= 3;
        }
        else
        {
            quant_de_refugiados = 150 + (int)(50 * Random.Range(0.0f, 1.0f));
            tempo_em_segundos = 15 + 15 * Random.Range(0.0f, 1.0f);
        }

        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            saida = saida_refugiados_1; entrada = entrada_refugiados_1;
        } else
        {
            saida = saida_refugiados_2; entrada = entrada_refugiados_2;
        }

        InstanciarIconeDeRefugiados(quant_de_refugiados, saida, entrada, tempo_em_segundos, escala);
    }

    // Use this for initialization
    void Start () {
        InstanciaAleatoriaInstantaneaDeOnda();
        InstanciaAleatoriaInstantaneaDeOnda();
        InstanciaAleatoriaInstantaneaDeOnda();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
