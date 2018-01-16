Title: Hello World exercise and description
order: 0
---
# Introduction
Entire exercise section is used to archive all assignments and solutions.

# Structure 
``` sql
exercises
├───cs
│       hello_world_exercise.md (Current file in Czech language)                
│       index.cshtml
│
├───en
│       hello_world_exercise.md (Current file)   
│       index.cshtml
│
├───media
│       hello_world_exercise_1.png (Image used in this file)
│
├───solutions
│   ├───cs
│   │       hello_world_exercise.md (Solution in Czech)
│   │
│   └───en
│           hello_world_exercise.md (Solution for this assignment)
│
└───sources
    └───hello_world_exercise (Resources for this exercise)
        │   someMatlabFunction.m
        │   someMatlabScript.m
        │
        └───folderWithImages 
                image01.png
                image02.png
```


Several links are automatically generated: 
- Link to a document if it is available in another language.
- Link to the solution, if available. Primary in assignment language.
- Link to folder with additional files (only if available).

# How does it work 
All language mutation files are paired by the same name. For example, this file has a name in all mutations `hello_world_exercise.md`. The same name has a solution file in the folder `solutions` and the folder with the files related to the assignment in folder `sources`. Sources are not available on web site only link redirecting to GitHub or [DownGit](https://minhaskamal.github.io/DownGit/#/Home) tool, that is used to download folders from GitHub. 

Images are shared for all language mutations, placed in `media` folder (to avoid duplications). It is a good practice to name image file according to “base filename”. Therefore, the following image is named `hello_world_exercise_1.png`. 

![](../media/hello_world_exercise_1.png)

# How to add an exercise
The simplest way for single language mutation is one file with a meaningful name in the folder of given language mutation. There is no need to add any metadata.

For more complex scenarios (adding language mutations, resources, solutions) follow this sample file. 



