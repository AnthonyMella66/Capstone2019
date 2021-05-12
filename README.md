# McMaster Engineering Capstone 2019/2020

## Virtual Reality Assistance Bot (Bot Factory)

### Group Members:

[Anthony Xavier Mella](https://github.com/AnthonyMella66)

[Jakub Pawlikowski](https://github.com/JPawlikowski)

[Hamid Yuksel](https://github.com/yukseltron) 

[Tyler Philips](https://github.com/Philipsty)

### Project Description

This is a proof of concept project for lab workers in the McDSL (McMaster Decision Science Lab) to add assistance bots to their virtual reality experiments. Having an assistance bot in a virtual reality simulation will greatly improve the experience of the simulation and as well provide better experiment results. This is because the experimentee will not have to exit the simulation to seek assistance which can negatively affect the results of the experiment. Given the nature of the experiments which is to conduct research on human behavior and decision making, it is important that the bot can provide consistent assistance so users can have a consistent experience. The assistance bot platform will be designed to be easily integratable into different simulations, as well as being customizable to provide assistance and give instruction when various events are triggered in the simulation.

The way the bot is able to communicate with the user in the simulation is through the [Google Cloud Text to Speech API](https://cloud.google.com/text-to-speech/) that is implemented in the [Frostweep Games Unity Asset](https://assetstore.unity.com/packages/add-ons/machinelearning/google-cloud-text-to-speech-115170). The asset made it possible to utilize the API within Unity and provide speech capabilities to the assistance bot. This makes the bot very robust when added to a simulation, since the API allows the bot to give direction and advice when specific events occur in a simulation. The bot is also able to respond to the users speech using the [Unity DictationRecognizer](https://docs.unity3d.com/ScriptReference/Windows.Speech.DictationRecognizer.html). The DictationRecognizer listens to keywords or phrases that the user speaks, and then replies a specific response specified in a config file.



To create or modify existing config files, you can use [this web app](https://bot-factory.netlify.app/).
