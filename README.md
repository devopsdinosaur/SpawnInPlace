# SpawnInPlace

## Purpose
- Player now spawns at death location with a 10-second (configurable in Config/buffs) invulnerability buff for running away
- Challenge quests no longer auto-fail on death
- Optional: Uncomment lines in Config/entityclasses to remove death XP penalty

## Mod Installation
Extract the archive or copy cloned git repo to <7D2D_Home>/Mods dir.  This mod uses Harmony and will only work with A20 and above.

## Building

### Build Prep 
- For best results, clone the repo directly into <7D2D_Home>/Mods directory.  The project file looks for files using relative paths.
- If you're modifying and building the code then be sure to install sphereii's 0-SCore mod/framework to enable the -autostart (starts the game after building and loads last savegame)

1. Clone or fork repo from GitHub: https://github.com/devopsdinosaur/SpawnInPlace
1. Open the .sln file using Visual Studio (Pro or Community 2019+)
1. Build the project.  It should rebuild the DLL and launch the game with the new mod.

Submit a pull request or send me an email if you have fixed code or new features to add.

## Thanks
- I used sphereii's guides and code for all the Harmony stuff

## Bugs / Issues / Requests
Email: devopsdinosaur _a_t_ gmail _d_o_t_ com)

