//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using UnityEngine;

//public class suitBotExample : MonoBehaviour
//{
//    public Transform suitBotTransform;
//    public SkinnedMeshRenderer skinnedMeshRendererSuit;
//    public Material blueMaterial;
//    public Material redMaterial;

//    int[] ConfParser()
//    {
//        //input file is a : separated flat text, take all integers (rhs of :) into array
//        StreamReader reader = File.OpenText("Assets/InputData/bot_config.txt");
//        string line;
//        int myInteger = 0;
//        int counter = 0;
//        int[] configInts = new int[4];  //NOTE: number of parameters in bot_config must match here
//        while ((line = reader.ReadLine()) != null)
//        {
//            string[] items = line.Split(':');
//            myInteger = int.Parse(items[1]);
//            configInts[counter] = myInteger;

//            Debug.Log(myInteger);
//            counter = counter + 1;
//        }
//        reader.Close();
//        return configInts;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//        {
//            file.WriteLine("-- Suit bot information below ---");
//        }
//        //array of configuration parameters from ConfParser function converted into element changes
//        int[] vals = ConfParser();
//        //bot position
//        if (vals[0] != 0)
//        {
//            if (vals[0] == 1)
//            {
//                suitBotTransform.position = new Vector3(372, 26, 467);
//                Debug.Log("Suit Bot position updated to : (372, 26, 467)");
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot material set to : (372, 26, 467)");
//                }
//            }
//            if (vals[0] == 2)
//            {
//                suitBotTransform.position = new Vector3(397, 26, 467);
//                Debug.Log("Suit Bot position updated to : (397, 26, 467)");
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot position updated to : (397, 26, 467)");
//                }
//            }
//        }


//        //bot scale
//        if (vals[1] != 0)
//        {
//            if (vals[1] == 1)
//            {
//                suitBotTransform.localScale = new Vector3(3, 7, 3);
//                Debug.Log("Suit Bot scale updated to : (3, 7, 3)");
//                //the below works for overwritting a file each time
//                //System.IO.File.WriteAllText(@"Assets/OutputData/bot_output.txt", "Suit bot scale updated to huhuHUHUHHU");

//                //the below is for appending to a file
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot scale updated to : (3, 7, 3)");
//                }
//            }
//            if (vals[1] == 2)
//            {
//                suitBotTransform.localScale = new Vector3(2, 9, 2);
//                Debug.Log("Suit Bot scale updated to : (2, 9, 2)");
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot scale updated to : (2, 9, 2)");
//                }
//            }
//        }

//        if (vals[2] != 0)   //if set to 0 then just use defaults
//        {
//            if (vals[2] == 1)
//            {
//                skinnedMeshRendererSuit.material = blueMaterial;
//                Debug.Log("Suit bot material set to : " + skinnedMeshRendererSuit.material);
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot material set to: " + skinnedMeshRendererSuit.material);
//                }
//            }
//            if (vals[2] == 2)
//            {
//                skinnedMeshRendererSuit.material = redMaterial;
//                Debug.Log("Suit bot material set to : " + skinnedMeshRendererSuit.material);
//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//                {
//                    file.WriteLine("Suit bot material set to: " + skinnedMeshRendererSuit.material);
//                }
//            }
//        }

//        //end section in output file
//        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/OutputData/bot_output.txt", true))
//        {
//            file.WriteLine("--- --- \n");
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}

