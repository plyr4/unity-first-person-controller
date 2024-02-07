# unity-first-person-controller

this repo contains some starter scripts for getting a project off the ground using Unity's new input management system to create a first person controller.

### features

so far, the code supports the following:
- player actions (WASD, space, mouse)
- player movement (horizontal, gravity, jumping)
- player looking (mouse input camera rotation)

### how to use

- create a new Unity project
- create a Plane and some other environment objects
- install and enable the new input system through the editor
- create input actions map if the script import doesnt work
- create a player object
- add a cylinder
- add a character controller
- add the inputmanager, playermovement and playerlook scripts to the player object
- move the camera under the player object, reset transforms, etc
- drag + drop the transforms, scripts, etc into the Serialized fields in the editor

### credits

built using a combination of a few youtube guides:
- https://www.youtube.com/watch?v=tXDgSGOEatk
- https://www.youtube.com/watch?v=_QajrabyTJc
- https://www.youtube.com/watch?v=5n_hmqHdijM

