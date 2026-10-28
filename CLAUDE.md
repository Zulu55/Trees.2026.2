# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Teaching project (course "Trees.2026.2") for binary trees in C# / .NET 10. Code is written to be read by students: recursive algorithms with explicit base-case comments, one concept per method. Keep that style (short methods, `// Base case: ...` comments, XML `<summary>` docs) when adding code.

## Commands

Solution file is `Trees.slnx` (new XML solution format; needs a .NET 10 SDK).

```bash
dotnet build Trees.slnx
dotnet run --project Frontend
```

There is no test project yet.

## Architecture

- **Backend** (class library) — all tree logic, generic over `T`:
  - `BinaryNode<T>` — the node type shared by everything (`Value`, `Left`, `Right`, `IsLeaf`).
  - `BinaryTreeOps` — static algorithms over *any* binary tree (traversals, level-order, iterative in-order, height in edges with empty = -1, count, leaves, linear `Contains`, `Max`, `Mirror`, `PrintSideways`). They take a `BinaryNode<T>` root, not a tree object.
  - `BinarySearchTree<T>` — BST insertion (duplicates ignored). Note its `Root`/`Count` are **static**, so they are shared across all uses of a given `T`; the Frontend uses the static `Insert(node, value)` overload directly on the tree loaded from file rather than the class's own `Root`.
  - `BinaryTreeFile` — loads/saves a tree from a flat text file, one node per line: `value,left,right` (`-` or empty = no child; first line is the root; `#` lines are comments; children without their own line become leaves). `Save` writes the same format in pre-order.
- **Frontend** (console app, top-level statements in `Program.cs`) — loads `tree.txt`, shows a numbered menu that calls `BinaryTreeOps` / `BinarySearchTree`, and saves back to `tree.txt` on exit (option `0`).

`tree.txt` is resolved relative to the current working directory and is not tracked in git (a copy currently lives only in `Frontend/bin/Debug/net10.0/`). Run the app from a directory containing `tree.txt`, or the load will throw.
