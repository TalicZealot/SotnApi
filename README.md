# SotN Api

An api for reading and manipulating game entities in ram through the BizHawk API.

## Usage
Download the dll from the release and reference in your project.
Create an instance of the api you want to use by passing the IMemoryApi provided by BizHawk to an ExternalTool at runtime.

## Building
Put a BizHawk folder in the folder that contains SotnApi.sln to reference the proper dll files.

## Contributions
I will continue to add functionality, but feel free to do so and make a pull request.
Please write unit tests and document your interfaces when appropriate.

## APIs
* ActorApi (Spawns, finds and edits actor entities in memory.)
* AlucardApi (Returns or sets Alucard's stats, equipment, statuses, timers)
* GameApi (Sets or returns different game-specific values such as the current area, zone, room. Can override string values. Can Respawn Bosses etc.)
* RenderingApi (Checks or draws on the minimap in VRAM)