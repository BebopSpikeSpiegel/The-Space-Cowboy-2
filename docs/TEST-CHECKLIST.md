# Next-boot test checklist (Phase 3 COMPLETE)

Deployed to the game's mods folder: **31 cards** (4 basic / 9 common / 9 uncommon / 9 rare),
**6 relics**, **8 powers**, full **eng + zhs** localization, static Spike combat sprite,
gun-smoke character-select scene. Built via `dotnet publish` (MegaDot export — required for
the scene; plain `dotnet build`+PckPacker no longer packs assets since a .tscn exists).

## Must-verify (fixes from previous sessions)

- [ ] **Reward screen after combat victory** — was soft-locking (all-Basic pool).
- [ ] **Big power icon on hover** — was a backslash-path bug.

## New this wave

- [ ] **Combat model is Spike** (STS1 standing sprite, static) — not Ironclad. Check attack
      lunge/hit flash look acceptable, HP bar/intents positioned sanely (BaseLib generates
      bounds from the 164x320 texture).
- [ ] **Character select background** — Spike 19:10 art with two drifting smoke emitters
      (positions are first-guess: muzzle ~(1210,640), cigarette ~(905,385) in 1920x1080
      layout — tell me where they should sit and I'll retune).
- [ ] **Ask DNA** (rare skill): next Attack this turn plays twice; buff icon shows; consumed
      after the doubled attack; upgraded copy doesn't Exhaust.
- [ ] **Carry That Weight** now has interim art (fallen Spike on dark backdrop).

## Standing spot-checks (from wave 2)

- Rain spend, Heavy Metal Queen / Bang. live-scaling damage + Flow dump, The Weight recoil
  (upgraded Bang. = no recoil), Asteroid Blues first-card bonus, Jupiter Jazz gate,
  My Funny Valentine retain+scaling block, Call Me Call Me selection screen, relics
  (Jericho first-attack Flow, Ein turn-1 draw, Big Shot gold, SYSC Buffer, Swordfish II
  +1 energy — sits in Ancient pool), zhs pass (English names, Chinese text, 得势 keyword).

## Build pipeline note

- **Ship builds: `dotnet publish`** (Godot export → dll+pck to mods). `dotnet build` still
  compiles + deploys the dll for code-only iteration, but skips the pck when scenes exist.
- MegaDot editor: `D:\Tools\megadot\4.5.1-m.14\` (GodotPath set in Directory.Build.props).
- A `SpaceCowboy.sln` now exists — required by the Godot .NET export plugin.

## Remaining (Phase 4)

Balance playtest (evaluate Gennadiyev/STS2MCP), smoke-emitter position tuning, proper
Carry That Weight art (ComfyUI), Workshop publish as NEW item.
STS1 mod: 0.0.7.1 Workshop publish still ON HOLD (wrong Steam account).
