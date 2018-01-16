using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genetic : MonoBehaviour
{
    IEnumerator Start()
    {
        PopulationInitial();
        for (int i = 0; i < Interations; i++)
        {
            print("ROUND: " + i);
            Instance();
            yield return new WaitForSeconds(60);
            Score();
            Organizer();
            Combinar();
        }
        GameObject go = Instantiate(Prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.GetComponent<Movement>().SetUp(population[0]);
        individuals.Add(go);
        print("Fin");
    }
    public GameObject Prefab;
    public int CandidateIndividuals = 15;
    public int Interations = 10;

    List<Individal3>population = new List<Individal3>();
    List<GameObject> individuals = new List<GameObject>();

    void PopulationInitial()
    {
        for (int i = 0; i < CandidateIndividuals; i++)
        {
            Individal3 ind = new Individal3();
            ind.AmplitudL = Random.Range(-20, 20);
            ind.AmplitudR = Random.Range(-20, 20);
            ind.OffsetXL = Random.Range(0, 1);
            ind.OffsetXR = Random.Range(0, 1);
            ind.OffsetYL = Random.Range(-30, 30);
            ind.OffsetYR = Random.Range(-30, 30);
            ind.FactorL = Random.Range(-10, 10);
            ind.FactorR = Random.Range(-10, 10);
           population.Add(ind);
        }
    }
    void Instance()
    {
        for (int i = 0; i < CandidateIndividuals; i++)
        {
            GameObject go = Instantiate(Prefab, new Vector3(0, 0, i*2), Quaternion.identity) as GameObject;
            go.GetComponent<Movement>().SetUp(population[i]);
            individuals.Add(go);
        }
    }
    void Score()
    {
        for (int i = 0; i < CandidateIndividuals; i++)
        {
            float puntuation = individuals[i].transform.position.x;
            puntuation = puntuation * ((individuals[i].transform.position.y > 10 || individuals[i].transform.position.y < -5) ? 0.1f : 1);
            Individal3 ind =population[i];
            ind.fitness = puntuation;
           population[i] = ind;
            Destroy(individuals[i]);
        }
        individuals = new List<GameObject>();
    }
    void Organizer()
    {
        //
        bool sw = false; // WRONG
        while (!sw)
        {
            sw = true;
            for (int i = 1; i <population.Count; i++)
            {
                if (population[i].fitness >population[i - 1].fitness)
                {
                    Individal3 ind =population[i];
                   population[i] =population[i - 1];
                   population[i - 1] = ind;
                    sw = false;
                }
            }
        }
    }
    public int MaintanceRate = 30;
    public int MutationRate = 20;
    void Combinar()
    {
        List<Individal3> Survivers = Evolution();
        int count = Survivers.Count;
        int missingPopulation =population.Count - count;
        for (int i = 0; i < missingPopulation; i++)
        {
            Individal3 Parent1 = Survivers[Random.Range(0, count)];
            Individal3 Parent2 = Survivers[Random.Range(0, count)];

            Individal3 ind = new Individal3();
            ind.AmplitudL = (Random.Range(0,100) > 50) ? Parent1.AmplitudL : Parent2.AmplitudL;
            ind.AmplitudR = (Random.Range(0, 100) > 50) ? Parent1.AmplitudR : Parent2.AmplitudR;
            ind.FactorL = (Random.Range(0, 100) > 50) ? Parent1.FactorL : Parent2.FactorL;
            ind.FactorR = (Random.Range(0, 100) > 50) ? Parent1.FactorR : Parent2.FactorR;
            ind.OffsetXL = (Random.Range(0, 100) > 50) ? Parent1.OffsetXL : Parent2.OffsetXL;
            ind.OffsetXR = (Random.Range(0, 100) > 50) ? Parent1.OffsetXR : Parent2.OffsetXR;
            ind.OffsetYL = (Random.Range(0, 100) > 50) ? Parent1.OffsetYL : Parent2.OffsetYL;
            ind.OffsetYR = (Random.Range(0, 100) > 50) ? Parent1.OffsetYR : Parent2.OffsetYR;

            ind.AmplitudL = (Random.Range(0, 100) > MutationRate) ? ind.AmplitudL : Random.Range(-20, 20);
            ind.AmplitudR = (Random.Range(0, 100) > MutationRate) ? ind.AmplitudR : Random.Range(-20, 20);
            ind.OffsetXL = (Random.Range(0, 100) > MutationRate) ? ind.OffsetXL : Random.Range(0, 1);
            ind.OffsetXR = (Random.Range(0, 100) > MutationRate) ? ind.OffsetXR : Random.Range(0, 1);
            ind.OffsetYL = (Random.Range(0, 100) > MutationRate) ? ind.OffsetYL : Random.Range(-30, 30);
            ind.OffsetYR = (Random.Range(0, 100) > MutationRate) ? ind.OffsetYR : Random.Range(-30, 30);
            ind.FactorL = (Random.Range(0, 100) > MutationRate) ? ind.FactorL : Random.Range(-10, 10);
            ind.FactorR = (Random.Range(0, 100) > MutationRate) ? ind.FactorR : Random.Range(-10, 10);

            Survivers.Add(ind);
        }
       population = Survivers;
    }
    List<Individal3> Evolution()
    {
        List<Individal3> Survivers = new List<Individal3>();
        for (int i = 0; i < CandidateIndividuals * MaintanceRate / 100f; i++)
        {
            Survivers.Add(population[i]);
        }
        return Survivers;
    }
}
