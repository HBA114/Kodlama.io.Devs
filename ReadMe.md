# Kodlama.io.Dev

## Senior Level Software Developer Training Camp (.Net) Homework_1

### Cloning Project

- You can open project with Visual Studio directly (recommended) with choosing Clone a Project section or you can use Github Desktop.

### How To Run This Project

- You have to run migratons first for running project as expected.

- Firstly choose src/Kodlama.io.Devs/WebAPI as Startup Project.

- Then open Package Manager Console. In Packace Manager Console window choose src/Kodlama.io.Devs/Persistence as default Project.

- Then run these commands in Package Manager Console in order:
```shell
add-migration initialMigration 
```
- This commands Creates a Migration Folder in src/Kodlama.io.Devs/Persistence and Adds a file named initialMigration. For apply migration run:

```shell
update-database
```

- Thats it. You can run project now. You can test functions and requests with swagger. Swagger will open when you run this project. Have a nice day 💻.

