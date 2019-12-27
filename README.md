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
