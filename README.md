# 🪽 Hermes: Query Engine

Hermes is a console-driven domain-specific language (DSL) engine designed to help nontechnical users define and execute complex, nested SQL queries using intuitive filter logic. Built with C# and Entity Framework Core, Hermes offers a clean, recursive architecture that balances extensibility, clarity, and raw expressive power.

## ✨ Why Hermes?

Creating database reports a la carte is conceivably possible for nontechnical actors—**if** they’re given the right tools. Hermes provides a foundation for building those tools.

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

- 🪄 **EF Core Integration**  
  Outputs LINQ expressions for direct translation to SQL via Entity Framework.

## 🧠 Design Principles

- 📋 **Domain-Driven Design**  
  If it's not in the data model, it doesn't exist.

- 🛑 **Don't Repeat Yourself**  
  Hermes is constructed with a *disgusting* level of inheritance and polymorphism—because reuse is holy.

- ✅ **Safety First**  
  Because it's better to use your bare hands than unreliable tools.
