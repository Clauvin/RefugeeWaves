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

    public int nextWaveId = 0;

    public GameObject refugees_exit_1, refugees_exit_2;
    public GameObject refugees_entrance_1, refugees_entrance_2;
    public float present_time = 0.0f;
    public float last_time;
    public float time_for_next = 0.0f;
    public int default_quantity_of_refugees = 50;
    public float default_time_in_seconds = 30.0f;

    void InstantiateNewRefugeeWave(int quant_de_refugiados, GameObject saida, GameObject entrada, float tempo_em_segundos,
            float escala = 1.0f)
    {
        GameObject icone = Instantiate<GameObject>(Resources.Load<GameObject>("Onda De Imigrantes"));
        icone.transform.position = new Vector3(saida.transform.position.x,
                                               saida.transform.position.y,
                                               saida.transform.position.z);
        icone.GetComponent<ImmigrantWave>().numberOfImmigrants = quant_de_refugiados;
        icone.GetComponent<MovingToTheObjective>().objetivo_final = entrada.transform.position;
        icone.GetComponent<MovingToTheObjective>().tempo = tempo_em_segundos;
        icone.name = "Icone de Refugiados - ID " + nextWaveId;
        if (escala > 1.0f)
        {
            icone.transform.localScale = new Vector3(icone.transform.localScale.x * escala,
                                                     icone.transform.localScale.y * escala,
                                                     1);
        }
        nextWaveId++;
    }

    void RandomInstantaneousWaveInstance()
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
            quant_de_refugiados = (int)(Random.Range(1.0f, 2.0f) * default_quantity_of_refugees);
            tempo_em_segundos = Random.Range(1.0f, 2.0f) * default_time_in_seconds;
        }
        else if (Random.Range(0.0f, 1.0f) < 0.05f)
        {
            quant_de_refugiados = (int)(Random.Range(15.0f, 20.0f) * default_quantity_of_refugees);
            tempo_em_segundos =  Random.Range(5.0f, 10.0f) * default_time_in_seconds;
            escala *= 3;
        }
        else
        {
            quant_de_refugiados = (int)(Random.Range(3.0f, 4.0f) * default_quantity_of_refugees);
            tempo_em_segundos = Random.Range(0.5f, 1.0f) * default_time_in_seconds;
        }

        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            saida = refugees_exit_1; entrada = refugees_entrance_1;
        } else
        {
            saida = refugees_exit_2; entrada = refugees_entrance_2;
        }

        InstantiateNewRefugeeWave(quant_de_refugiados, saida, entrada, tempo_em_segundos, escala);
    }

    // Use this for initialization
    void Start () {
        time_for_next = Random.Range(30.0f, 60.0f);
        last_time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        present_time += Time.time - last_time;
        last_time = Time.time;

        if (present_time >= time_for_next)
        {
            RandomInstantaneousWaveInstance();
            present_time = 0.0f;
            if (TimeManager.instance.year == 1)
            {
                time_for_next = Random.Range(30.0f, 60.0f);
            } else
            {
                time_for_next = Random.Range(15.0f, 30.0f);
            }
        }
	}
}
