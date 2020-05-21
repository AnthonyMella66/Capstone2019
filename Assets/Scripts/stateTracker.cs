using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class stateTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int numStates = 10;
        List<State> stateList = new List<State>();
        for (int i = 1; i <= numStates; i++) { stateList.Add(new State(i)); }

        for (int j = 0; j < numStates; j++)
        {
            stateList[j].StartState();

            //this for loop is used to fill in time between the theoretical states being created
            int count = 0;
           for(int k = 0; k < 100; k++) { count++; }

            stateList[j].EndState();
        }
    
        
        System.IO.File.WriteAllLines(@"Assets/OutputData/ProgressionStats.txt", stateList[0].GetStatistics(numStates, stateList));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
