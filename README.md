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
    (1) Create enums as the key for the each State register in state machine
    (2) Create context class extend from StateContextBase
    (3) Create each specific state by extending StateBase<T> with T is the class created from (2)
    (4) Create a dictionary to map state and key
    (5) Create an instance of context class
    (6) Create instance of StateMachine class
    (7) Change the state machine to initial class
    (8) Call update function of state machine inside a Update function of Unity
