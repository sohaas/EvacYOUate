# EvacYOUate
HRI project

## Installation
Go to https://unity.com/de/download?_ga=2.147327223.1120578917.1638948601-1822498321.1638948601 to install Unity Hub.
In Unity Hub, go to Installs and install the 2019.4.33f1 Unity Editor Version. Add the following modules (for windows):
Microsoft Visual Studio Community 2019, Universal Windows Platform Build Support, WebGL Build Support, Windows Build
Support (IL2CPP) and Documentation.
Install GitHub Desktop: https://desktop.github.com/.
Now go to https://github.com/sohaas/EvacYOUate, select Code and Open with GitHub Desktop and clone the repository.
In Unity Hub, go to Projects and open the project from disk by selecting the UnityProject folder (path to the git repository).
Click to open the projet in Unity Hub.

## Player Interaction
* Right hand: Continuous/snap turn
* Left hand: Continuous movement, teleportation

## Testing the Project without HMD
To test the project click the play button. Now, the following inputs can be given via keyboard:

1. Camera:
* Up/down/left/right movement: Right mouse key pressed + move the mouse
* Forward/backward movement: Right mouse key pressed + scroll the mouse wheel

2. Right hand:
* Up/down/left/right movement: Space pressed + move the mouse
* Forward/backward movement: Space pressed + scroll the mouse wheel
* Tilt: Space + control pressed and move the mouse
* Grab object: Space pressed + ray points at XR grab interactable object (ray color changes from red to white) + press G key (will probably not be used in the project)
* Continuous turn: Space pressed + press A/D key to turn left/right

3. Left hand:
* Up/down/left/right movement: Shift pressed + move the mouse
* Forward/backward movement: Shift pressed + scroll the mouse wheel
* Tilt: Shift + control pressed and move the mouse
* Grab object: Shift pressed + ray points at XR grab interactable object (ray color changes from red to white) + press G key (will probably not be used in the project)
* Teleport: Shift pressed + ray points at Teleportation Anchor/Area (ray color changes from red to white) + press G key
* Continuous movement: Shift pressed + press W/A/S/D key to move forward/left/backward/right

4. Combination:
* Move camera and both hands simultaneously:
  Right mouse key + space + shift pressed and move the mouse or scroll the mouse wheel