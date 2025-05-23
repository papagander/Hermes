# 🪽 Hermes: Query Engine

Hermes is a console-driven domain-specific language (DSL) wizard designed to help users create and execute complex SQL queries using intuitive and readable filter logic. Built with C# and Entity Framework Core, Hermes offers a clean, recursive architecture that balances extensibility, clarity, and raw expressive power.

<img width="1440" alt="Screenshot 2025-05-12 at 4 18 36 PM" src="https://github.com/user-attachments/assets/f2215e9a-38a0-4967-bd16-0916e4844898" />



## Installation Guide

### 🔹 Step 1: Install [Git](https://git-scm.com/downloads)

### 🔹 Step 2: Install .NET 8 SDK from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  

### 🔹 Step 3: Download Hermes Source Code  
  
Run the following wherever you want to install the source code (it'll all be contained in one folder):  

```bash / git bash
git clone https://github.com/papagander/Hermes.git
cd Hermes/Hermes_Console
echo yeeee haw
```  

### 🔹 Step 4: Build and install Hermes  

Run the following from somewhere/Hermes/Hermes_Console:

```bash
dotnet build
dotnet pack -c Release
dotnet tool install --global --add-source ./bin/Release Hermes_Console
```

### ♦️ If you ever want to uninstall:  
```bash
dotnet tool uninstall --global Hermes_Console
```

### 🔹 Step 5: Run Hermes   

Just go literally anywhere and type:  
```bash
Hermes_Console
```

which will bring you into Hermes's top level menu. I recommend entering the Query menu and clicking 'show' to start. This will show the sample query loaded into the seeded database.  

Upon returning to the query menu, you can create a new query. The wizard does a reasonably good job of guiding the user through constructing the query. 

Quitting the Query menu will take you back to the top menu. The datacore -> operators menu -> show function will expose the details for the filter functions Hermes uses to build query filters.




## ✨ Why Hermes?

SQL is not pretty. SQL is not always very helpful. SQL does not care how soon you need your inventory reports. But Hermes cares. Hermes offers a framework to abstract and store commonly applied filters as parameterized functions, and combine those functions as the user wishes in order to create complex queries.

It offers:
- A **modular, composable system** where new interfaces or tools can interoperate with the core
- A clean DSL designed for interpretability and extension
- A way for developers to **expose new data sources** and **define custom, parameterized, type-safe operations**

Once a query has been instantiated, other systems can generate reports from it, and in theory, reports could be modified on the fly by nontechnical administrators.  
(*Note: the CLI does not currently support modifying existing queries.*)

Hermes isn't a drag-and-drop dashboard. It’s the **backend logic layer** you build dashboards *on top of*—with structure you can trust and extend without fear.

It bridges the gap between human-readable configuration and fully dynamic, type-safe query construction.

## ⚙️ Core Features

- 🧾 **Dynamic Filter Trees**  
  Recursively construct and evaluate filter logic (`AND`, `OR`, etc.) from user-defined structures.

- 🗣️ **DSL Interface**  
  Users define filters and conditions via a structured input format interpreted at runtime.

- 🛠️ **Command-Line Interface**  
  Lightweight, readable, and expressive text-based interface for building and previewing queries.

- 🧩 **Modular + Extensible**  
  Clean separation of concerns makes it easy to add new operators, data sources, and output targets.
