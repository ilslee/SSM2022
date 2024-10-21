using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.game.input{
    public class GameViewUITestInerface : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)){
                //Wheel Interfece Open/Close
            }else if(Input.GetKeyDown(KeyCode.S)){
                //Open-Close Start View
            }else if(Input.GetKeyDown(KeyCode.N)){
                //Open-Close End View
            }else if(Input.GetKeyDown(KeyCode.C)){
                //Open-Close Character Power Window
            }else if(Input.GetKeyDown(KeyCode.V)){
                //Open-Close Opponent Power Window
            }else if(Input.GetKeyDown(KeyCode.N)){
                //Open-Close NextAction
            }else if(Input.GetKeyDown(KeyCode.Q)){
                //Modify Character HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.A)){
                //Modify Character EP to Random Value
            }else if(Input.GetKeyDown(KeyCode.E)){
                //Modify Opponent HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.D)){
                //Modify Opponent HP to Random Value
            }else if(Input.GetKeyDown(KeyCode.R)){
                //Modify Character Status
            }else if(Input.GetKeyDown(KeyCode.F)){
                //Modify Opponent Status
            }
        }
    }
}