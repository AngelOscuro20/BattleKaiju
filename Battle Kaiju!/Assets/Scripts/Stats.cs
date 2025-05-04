using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats : MonoBehaviour

{
    //ID del kaiju,usada para el codigo de evolucion
    public int ID;
    public string Nombre;
    public string estadioEvolutivo;
    public int tipo; //1:offensivo,2:defensivo,3:evasivo
    //Tiempo de evolucion TOTAL desde el huevo
    public int evolutiontime;
    public int attack;
    public int HP;
    public int Defense;
    public int speed;
}

