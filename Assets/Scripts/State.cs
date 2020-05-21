using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
/*
* Tyler Philips
*
*State objects will have a timer that can be controlled with StartState and StopState functions
*this time will be used to keep track of user progression
*/

public class State : MonoBehaviour
{

    //global variables
    private Stopwatch timer;
    private int id;
    private string output;
    private float totalTime;

    //State objects have 4 attributes
    //timer is a Stopwatch variable to record time elapsed
    //id is a unique int value for each object
    //output is a string variable that will be used to share final results
    //totalTime is a float reprentation of timer to be used in calculating average
    public State(int identity)
    {
        this.timer = new Stopwatch();
        this.id = identity;
        this.output = "";
        this.totalTime = 0;
    }

    // StartState will start the timer for a given State object
    public void StartState()
    {
        this.timer.Start();
    }

    // EndState will end the timer for a given State object
    // the 'output' variable is set to contain
    // the details of the given state object that will later
    // be written to a file
    // the 'totalTime' variable is calculated to include the 
    // elapsed time in a state
    public void EndState()
    {
        // hours minutes seconds milliseconds
        float h, m, s, ms;

        this.timer.Stop();

        // calculate the total amount of time passed as a float
        // note that different variables can be used depending on 
        // how long the state is expected to take
        // in this case milliseconds is most fitting to use, however
        // it can be replaced with any of the following code:
        // h  = (float)Elapsed.Hours;
        // m  = (float)Elapsed.Minutes;
        // s  = (float)Elapsed.Seconds;
        ms = (float)timer.Elapsed.Milliseconds / 1000;
        this.totalTime = ms;

        // setting output
        this.output = "\nState " + this.id + " :\n" + this.timer.Elapsed + "\n= " + this.totalTime + " seconds";
    }

    // GetTotalTime returns a float value corresponding to 
    // the total time spent in a state
    public float GetTotalTime()
    {
        return this.totalTime;
    }

    // GetOutput returns output string
    public string GetOutput()
    {
        return this.output;
    }

    // GetStatistics will only be run by a simulations first state 
    // this function will calculate the average state time and total time 
    // it will then return a string list to be printed to an output file
    // numStates holds the number of states in a game/simulation
    // stateList is a list of the state objects used in main code
    // average will hold the average time spent in each state 
    // total will hold the total time in a playthrough
    // stateStats is a list of strings that will be returned to 
    //     be printed to a file
    public string[] GetStatistics(int numStates, List<State> stateList)
    {
        float average = 0;
        float total = 0;
        string[] stateStats = new string[numStates + 2];

        //filling stateStats with game/simulation statistics
        stateStats[0] = "\nProgression Statistics\n==========================================\n\n~Time elapsed per game state~\nformat: hours:minutes:seconds:milliseconds\n\n";
        for (int i = 0; i < numStates; i++) { stateStats[i + 1] = stateList[i].GetOutput(); total += stateList[i].GetTotalTime(); };
        average = total / 12;
        stateStats[numStates + 1] = "\n\nAverage time per state = " + average + " seconds\nTotal Time = " + total + " seconds";

        //return statistics in the form of a list
        return stateStats;

    }


}

