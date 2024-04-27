# Tutorial jumper-oefening


## Introductie
In deze tutorial maken we een zelflerende Agent dat wordt geconfronteerd met een rij van objecten.

## Stappen:

### Setup Environment:
- Installeer Anaconda navigator om onze agent te trainen
- Installeer unity.

### Creatie jumper agent:
- Maak een 3d game object aan dat onze agent representeert
- Ontwikkel een script voor het gedrag van onze agent, inclusief collision detection wanneer de agent een obstakel raakt en beweging van de agent, zoals een sprong wanneer de perceptieray een obstakel detecteert. Een voorbeeld van dit script is beschikbaar in de repository.
  

### Creatie obstacle:
- Maak een 3d game object aan als obstacle in mijn geval heb ik een cube gebruikt als obstacle.
- Ontwikkel een script voor de beweging van het obstakel, waarbij het obstakel een beloning geeft aan de agent wanneer het tegen de muur botst, omdat dit aangeeft dat de agent succesvol is gesprongen. Een voorbeeld van dit script is beschikbaar in de repository.

## Agent Reward functie:
- -0.001 penalty wanneer onze agent spring. Dit voorkomt dat de agent teveel springt.
- 0.5 reward wanneer obstacle muur aanraakt. Dit betekend dat de agent heeft gesprongen.
- -1.0 penalty wanneer agent en obstacle botsen. Dit geeft de agent motivatie om te springen.

## Behavior parameters:
- Space size: 0
- Stacked vectors: 1
- Continues actions: 2
- Branches: 1
- Branch 0 size: 2
### Testen:
- U kunt uw omgeving manueel testen met de Heuristic methode voor dat je begint met trainen.  
  
### Training agent: 
- Om de agent te trainen, gebruiken we Anaconda Navigator. Hier maak je een omgeving aan en open je de terminal. Navigeer naar je repository in de geopende terminal en voer het volgende commando uit: "mlagents-learn config/CubeAgent.yaml --run-id=CubeAgent"
- 
### Tensor board:
Ik heb problemen met het trainen van mijn agent opgelost door het beloningssysteem aan te passen. Nu straf ik het voor overmatig springen en beloon ik het voor het vermijden van obstakels. Hierdoor leert mijn agent efficiënter, maar een grote straf kan de indruk wekken dat het niet goed leert.Je moet zelf zien wat de beste rewardering parameters zijn voor uw agent. Wat ik ook heb gedaan, is mijn scenario omgezet naar een prefab en dit meerdere keren gekopieerd en geplakt. Hierdoor kon mijn agent veel sneller trainen. Hieronder een screenshot van mijn tensorboard.
![image](https://github.com/AP-IT-GH/jumper-assignment-Henried1/assets/96701358/1fc6518e-8d14-4aec-8fcf-a284cc1505c9)



### Conclusie:
- Door de stappen in deze tutorial te volgen, kun je een gameomgeving maken waarin een jumper agent obstakels kan ontwijken door te springen. Experimenteer met verschillende parameters en trainingsmethoden om de prestaties van je agent te verbeteren
