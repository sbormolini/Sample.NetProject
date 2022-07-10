# SampleProject
.NET Project Folders Structure

- artifacts: where the build.cmd script puts the artifacts
- build: build customizations
- docs: markdown files, installation instructions, help files. I use this folder to put the Docusaurus project
- lib: if you have a custom library outside of NuGet, you can copy the files here
- samples: sample projects to use your solution or projects
- src: the code of your projects
- tests: all the tests projects live here
- .editorconfig: coding styles and other settings for your environment
- .gitignore: I think you don't need a description about it
- build.cmd: the script to build the project and create artifacts (I don't use it very often)
- LICENSE: the license file of your project. Useful especially for GitHub
- Project001.sln: the solution file of your projects
- README.md: useful for GitHub but also to give an overview of the project to the other people involved

Source:
https://dev.to/kasuken/net-project-folders-structure-36o8
