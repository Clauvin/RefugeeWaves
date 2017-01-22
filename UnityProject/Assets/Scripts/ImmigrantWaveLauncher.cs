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

    void InstanciarIconeDeRefugiados(float x, float y, int quant_de_refugiados, GameObject saida, GameObject entrada, float tempo_em_segundos)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Onda De Imigrantes"));
        icone.transform.position = new Vector3(saida.transform.position.x,
                                               saida.transform.position.y,
                                               saida.transform.position.z);
        icone.GetComponent<ImmigrantWave>().numberOfImmigrants = quant_de_refugiados;
        icone.GetComponent<MovingToTheObjective>().objetivo_final = entrada.transform.position;
        icone.GetComponent<MovingToTheObjective>().tempo = tempo_em_segundos;
        icone.name = "Icone de Refugiados - ID " + idDoProximoIcone;
        idDoProximoIcone++;
    }

    // Use this for initialization
    void Start () {
        InstanciarIconeDeRefugiados(5.0f, 2.0f, 1000, saida_refugiados_1, entrada_refugiados_1, 20.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
