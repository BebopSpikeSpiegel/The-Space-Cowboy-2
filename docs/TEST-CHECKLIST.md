# Next-boot test checklist (post wave 2, commit c15544d)

Deployed to the game's mods folder: **30 cards** (4 basic / 9 common / 9 uncommon / 8 rare),
**6 relics**, **7 powers**, full **eng + zhs** localization. Build clean, not yet booted
(per request, no game launches from the agent).

## Must-verify (bug fixes from last session)

- [ ] **Reward screen after combat victory** — was soft-locking ("stuck on enemy death"):
      pool had only Basic cards, rarity roll threw. Now commons/uncommons/rares exist.
- [ ] **Big power icon on hover** (e.g. Flow) — was `res://SpaceCowboy\images\...` backslash
      path (template's Path.Join bug); now forward slashes.

## New content spot-checks

- [ ] Card rewards offer Spike commons/uncommons/rares with STS1 art.
- [ ] **Rain**: 7 block + auto-spends up to 3 Flow (+3 block each).
- [ ] **Heavy Metal Queen / Bang.**: displayed damage grows live with Flow; on play, Flow
      drops to 0. Bang. also applies **The Weight** (lose 8 HP next turn) and Exhausts;
      upgraded Bang. shows Weight 0 and applies nothing.
- [ ] **Asteroid Blues**: bonus Flow only when it's the first card of the turn.
- [ ] **Jupiter Jazz**: end of turn with 3+ Flow → +1 Strength; below 3 → nothing.
- [ ] **My Funny Valentine**: Retain + block equals current Flow.
- [ ] **Call Me Call Me**: opens discard-pile selection screen; chosen card to hand.
- [ ] **Carry That Weight**: damage scales +3 per exhausted card (art is a placeholder).
- [ ] Relics: Jericho 941 (first Attack per turn → 1 Flow), Ein (turn-1 +1 draw),
      Big Shot (+25g after victory), See You Space Cowboy (1 Buffer at combat start),
      Swordfish II (+1 energy/turn, +2 Flow at combat start; sits in the Ancient pool —
      STS2 has no Boss rarity, flag if that feels wrong in rewards).
- [ ] **zhs**: switch language to 简体中文 — English card names + Chinese rules text,
      keyword 得势 tooltips, character select shows 星际牛仔.

## Known gaps / deferred

1. **Ask DNA** not implemented ("next attack plays twice" needs research into STS2's
   play-doubling; CardPlay.PlayCount/PlayIndex exist, so an engine mechanism likely does).
2. **Carry That Weight card art** — needs a ComfyUI generation pass (STS1 has none).
3. **Combat model is Ironclad, char-select bg is Ironclad** — MegaDot art pass planned:
   static Spike sprite via `CreateCustomVisuals`, `char_select_bg_spacecowboy.tscn` with
   two GPUParticles2D smoke emitters (muzzle + cigarette, reusing base-game
   `common_round_smoke_a.png`) + cig glow AnimationPlayer.
4. Balance pass + playtest (evaluate Gennadiyev/STS2MCP), then NEW Workshop item (Phase 4).
5. STS1 mod: 0.0.7.1 Workshop publish still ON HOLD (wrong Steam account).
