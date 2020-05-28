# Unity-State-Machine
Simple implementation of State Machine in Unity
# Namespace
Kultie.StateMachine
# Feature
## State Machine
- Vanila StateMachine patern using dictionary to manage states
- State model using IState interface
- Context model using IStateContext
### Function
- Constructor(dictionary): Create a State Machine with dictionary as states list
- Change(name, context): Change current state to state with the name in dictionary
- Update(dt): Update current state with delta time dt

## State Stack
- Stack-like state machine where every state will be update from top to bottom of the stack
- State model using IStateStackState interface
- Context model using IStateContext
### Functions
- Constructor: Create a new State Stack 
- Pop(): Remove state at top of the stack
- PopAll: Remove all states from stack
- Push(context): Push a state into a stack with a context
- Top(): Return state at the top of the stack
- Update(dt): Update every state in stack start from top of State

# How to use
## State Machine
- Go to Demo/Scenes/DemoScene to view the simple implementation by utilizing Console to log the process of state machine
- Basic work flow for creating a State Machine:
    - Create enums as the key for the each State register in state machine
    - Create context class extend from StateContextBase
    - Create each specific state by extending StateBase<T> with T is the class created from step two
    - Create a dictionary to map state and key
    - Create an instance of context class
    - Create instance of StateMachine class
    - Change the state machine to initial class
    - Call update function of state machine inside a Update function of Unity
- You can go to State Machine/ Template and typing the namespace, the state key and the context to quickly creating a state machine template to work with
- The generated file will be locate at Assets/StateMachine/`Your namespace`. Inside that will have a commented code snippet for you to copy and paste inside your controller script

# Update 28/5/2020
- Change old demo scene to StateMachine Instance Demo
- Added a basic state machine that can be added in the game object editor
    - Namespace: Kultie.StateMachine.Behavior
    - Basic workflow are:
        - Create new gameobject
        - Add StateMachineComponent to gameobject
        - Create a new component script extends from StateContextComponent and add your data there
        - Add created context component script to the gameobject
        - Create as many state as you want extend from StateComponent and implments all abstract stuffs
        - Add them to gameobject
        - Drag gameobject to the State Container of StateMachineComponent
        - Drag gameobject to the Context of StateMachineComponent;
    - There are Demo inside Demo/Scenes/StateMachine Behavior Demo
