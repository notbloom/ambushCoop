```mermaid

flowchart TD
Board --> Map
Board --> Player
Player --> Equipment
Equipment -- Collection --> StatModifiers 
Equipment -- Collection --> Skills
Equipment -- Collection --> Passives
```


### Actions

```mermaid

flowchart LR

ActionFactory --> ActionController
ActionController --> ActionInstance


```

Action Types: 

DamageInstance
Movement

