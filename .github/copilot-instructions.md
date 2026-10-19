# GitHub Copilot Instructions for Quest Progression Nerf (Continued) Mod

## Mod Overview and Purpose

**Quest Progression Nerf (Continued)** is an update and reimplementation of the original mod by **newcolonist**. It's designed to rebalance the threats in RimWorld quests, particularly targeting end-game scenarios. By rewriting the mod using RimWorld 1.3's mod-logic and removing redundant components, we've enhanced mod compatibility. Notable changes include shifting to a Harmony postfix approach and eliminating the old "vanilla calculation" option.

## Key Features and Systems

- **Quest Difficulty Levels:** Offers three progressive difficulty settings: Default, High, and the extreme Ludeonicrous (Vanilla). Default is recommended for balanced gameplay.
- **Progression Nerfing:** Adjusts progression to prevent an impractical number of structures, like the 45x70 buildings, from appearing in the mid to late game.
- **Compatibility:** Designed to work alongside mods like 'Quest Reward Rebalance' for enhancing mid-late game rewards.

## Coding Patterns and Conventions

- **Naming Conventions:** 
  - Use PascalCase for class and method names (e.g., `QuestsMod`, `StorytellerUtility_GetProgressScore`).
  - Use camelCase for local variables and parameters.

- **Code Structure:** 
  - Organize related functionalities within specific files and namespaces.
  - Maintain separation of concerns by keeping logic, configuration, and data handling in distinct files.

- **Error Handling:** 
  - Use logging for error reporting and debugging. Request that users use the official Discord channel for error reporting.
  - Encourage the use of Log Uploader for better support and diagnostics.

## XML Integration

- **Mod Metadata in About.xml:**
  - Ensure the `About.xml` file includes essential metadata such as `Name`, `Author`, `PackageId`, and `Dependencies`.
  - Follow XML syntax rules strictly to avoid errors during parsing.

## Harmony Patching

- **Use of Harmony Library:**
  - Replace static calculations with dynamic patches using Harmony postfics (`Postfix`) for greater compatibility and flexibility.
  - Be sure to maintain Harmony conventions, like using `[HarmonyPatch]` attributes to specify methods for patching.
  
- **Managing Mod Compatibility:**
  - Harness the power of Harmony to apply changes post-execution, thereby ensuring the mod cooperatively interacts with other mods.

## Suggestions for GitHub Copilot

- Utilize Copilot to:
  - Suggest method signatures and class templates based on existing conventions.
  - Generate XML snippets with correct syntax for metadata and configuration.
  - Provide boilerplate Harmony patching code, reducing the repetitive coding overhead.
  - Initiate logging code or error handling patterns for debugging purposes.

Remember to keep engaging with the community on potential improvements and bug reports, helping ensure a seamless gaming experience for all users.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

