# SotN Api
[![(latest) release | GitHub](https://img.shields.io/github/release/TalicZealot/SotnApi.svg?logo=github&logoColor=333333&style=popout)](https://github.com/TalicZealot/SotnApi/releases/latest)

An api for reading and manipulating game entities in ram through the BizHawk API.

## Usage
Download the dll from the release and put it in the ExternalTools folder. Reference in your project and use.
Create an instance of the api you want to use by passing the IMemoryApi provided by BizHawk to an ExternalTool at runtime.

## Building
Put a BizHawk folder, containing the most recent release, in the folder that contains SotnApi.sln to reference the proper dll files. You might need to redo some reference to build.

## Contributions
I will continue to add functionality, but feel free to do so and make a pull request.
Please write unit tests and document your interfaces when appropriate.

## APIs
* EntityApi: Can spawn, find and edit entities.
* AlucardApi: Contains properties and functions affecting Alucard stats, gear, status and more.
* GameApi: Contains properties and functions that relate to the game.
* MapApi: Checks or draws on the minimap in VRAM.