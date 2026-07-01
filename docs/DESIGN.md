# The Space Cowboy — STS2 Design Doc (Phase 1)

Adaptation of the STS1 Spike mod to STS2's design language. Not a 1:1 port: same identity
(Flow momentum engine), deepened the way Mega Crit reworked Ironclad/Silent for the sequel.
Calibration anchor: STS2 Strike is unchanged (6 dmg, +3 on upgrade), so STS1 post-0.0.7.1
numbers are the starting baseline.

## Identity

- **HP 80** (fragile-ish brawler), 3 Energy, starting gold 99.
- **Flow** (stacking power): builders add it, spenders consume it, payoffs gate on it.
  Persists between turns. No cap. (STS1-faithful.)
- **NEW — "In the Flow"** (named keyword, replaces STS1's repeated "if you have 3 or more
  Flow"): *you are In the Flow while you have 3+ Flow.* Cards read "In the Flow: …".
  Localized via `card_keywords.json` (eng + zhs `入流`/`势` tbd with user).
- **NEW STS2-native hook — the exhaust pile ("carry that weight").** STS2 Ironclad made
  exhaust-pile interaction a first-class archetype (Ashen Strike, Pact's End). Spike's
  movie/loss theme maps perfectly: a light subtheme (3 cards) that counts or feeds the
  exhaust pile. Deliberately light — Flow stays the core.

## Keyword spec: In the Flow

- Condition: current Flow ≥ 3. Purely derived; no separate power.
- UI: keyword hover tip on every card that uses it (static_hover_tips or card_keywords).
- zh: keyword name candidate `入流` (enter the flow), tooltip references `势`.

## Starting deck (10)

| Card | Design | Notes |
|---|---|---|
| 4× Straight Lead | 1c Attack, 6 dmg (+3) | = Strike |
| 3× Dodge | 1c Skill, 5 block (+3) | = Defend |
| 1× Shoot | 1c Attack, 5 dmg + 1 Vulnerable (+: 8 dmg + 2 Vuln) | STS1 0.0.7-final numbers, adjusted to STS2 Vulnerable being a pillar |
| 2× Jeet Kune Do | 1c Attack, 6 dmg, gain 1 Flow (+: 8) | signature starter; 2 copies (was 1) so Flow is live from fight one |

(STS1 had 4 Dodge + 1 JKD; shifting one slot to JKD makes the identity show up earlier —
mirrors how STS2 starters teach the character's gimmick immediately.)

## Commons (9, from STS1's 10)

| Card | Design | Change vs STS1 |
|---|---|---|
| Don't Bother None | 1c Atk, 8 dmg, +1 Flow (+: 11) | **absorbs Rush** (was a near-dupe) |
| Bad Dog No Biscuits | 1c Atk, 4 dmg ×2 (+: ×3) | keep |
| Spokey Dokey | 0c Atk, 5 dmg (+: 8) | keep |
| Felt Tip Pen | 0c Skill, draw 1, +1 Flow (+: draw 2) | keep |
| Rain | 1c Skill, 7 block; spend up to 3 Flow → +3 block each (+: 9 block, spend 4) | keep (0.0.7.1 numbers) |
| Memory | 1c Skill, 6 block, +1 Flow (+: 9) | keep |
| Farewell Blues | 1c Atk, 7 dmg, draw 1 (+: 10) | keep |
| 24 Hours Open | 1c Skill, 6 block, draw 1 (+: 8 block) | **absorbs Waltz for Venus** (dupe) |
| Fantaisie Sign | 0c Skill, +2 Flow (+: +2 Flow, draw 1) | keep; **absorbs Honky Tonk Women** (dupe) |

## Uncommons (11, from STS1's 15)

| Card | Design | Change |
|---|---|---|
| Heavy Metal Queen | 2c Atk, 10 dmg +3 per Flow, lose ALL Flow (+: 12, +3/Flow) | keep — big spender |
| Sympathy for the Devil | 1c Atk, 7 dmg, heal 2; **In the Flow:** heal 5 (+: 9 dmg) | reword to keyword |
| Cowboy Funk | 1c Atk, 5 dmg ×2; **In the Flow:** hit once more, spend 3 Flow (+: 6×2) | reword to keyword |
| Speak Like a Child | 1c Skill, draw 2, +1 Flow (+: draw 3) | keep |
| Mushroom Hunting | 0c Skill, +2 Flow, draw 1, Exhaust (+: +3 Flow) | keep — feeds exhaust subtheme |
| Green Bird | 1c Skill, 5 block, +1 Dexterity (+: 7 block) | keep |
| Jupiter Jazz | 1c Power: end of turn, **In the Flow:** gain 1 Str (+: 2 Str) | 0.0.7.1 gated design, keyword wording |
| Asteroid Blues | 1c Atk, 8 dmg; if first card this turn: +2 Flow (+: 11) | keep |
| My Funny Valentine | 1c Skill, Retain; gain 1 block per Flow (+: 2/Flow) | keep |
| Goodnight Julia | 0c Skill, lose 3 HP, +2 Flow, draw 1 (+: lose 2) | keep |
| Call Me Call Me | 1c Skill, copy a random discard-pile card to hand, +1 Flow (+: chosen card) | keep (STS1 0.0.6 rework) |

**Cut:** Honky Tonk Women (→ Fantaisie Sign+), Skies of Ganymede (Shoot dupe),
Bohemian Rhapsody (STS2 has no Scry — cut rather than redesign; scry role partly covered
by draw density).

## Rares (10, from STS1's 11)

| Card | Design | Change |
|---|---|---|
| Bang. | 2c Atk, 12 dmg +4/Flow, lose all Flow, Exhaust; next turn: lose 8 HP (Carry That Weight) (+: no HP loss) | signature, unchanged |
| Ballad of Fallen Angels | 2c Atk AoE, 8 dmg all, +2 Flow (+: 11) | keep |
| Tank! | 1c Power: +2 Flow at start of turn (+: +3) | keep (STS1 numbers) |
| The Real Folk Blues | 3c Atk AoE, 12 dmg all, draw 2, +2 Flow (+: 15) | keep |
| Space Lion | 2c Power: whenever you lose HP, +1 Str (+: 2c→1c) | keep |
| Jamming with Edward | 1c Skill, +1 Flow per card in hand, draw 2, Exhaust | keep |
| Ave Maria | 1c Atk, 8 dmg; **In the Flow:** 20 dmg instead, Exhaust (+: 24) | reword (STS1 gate was 5 Flow → now uses keyword at 3; damage tuned down 26→20/24) |
| Blue | 3c Power: whenever you play a card, +1 Flow (+: 2c) | keep — capstone engine |
| Gotta Knock a Little Harder | 2c Atk, 9 dmg; ≤50% HP: double (+: 12) | keep (movie) |
| **NEW: You're Gonna Carry That Weight** | 1c Atk, 3 dmg +3 per card in your exhaust pile (+: +4/card) | STS2-native exhaust payoff; pairs with Bang./Mushroom/Jamming/Ask DNA |

**Cut:** Road to the West (Bang-without-drawback occupied the same slot as Heavy Metal
Queen; its identity folds into HMQ+).
**Moved:** Ask DNA → stays rare: 1c Skill, next attack this turn plays twice, Exhaust
(+: no Exhaust).

Total: 4 basics + 9 commons + 11 uncommons + 10 rares = **34 cards** (from 41).

## Relics (6)

| Relic | Design | Change |
|---|---|---|
| Marlboro (starter) | +2 Flow at combat start | keep |
| Jericho 941 | first Attack each turn: +1 Flow | keep |
| Ein | **redesign (no Scry):** at combat start, draw 1 extra card | was scry 3 |
| Big Shot | +25 gold per combat victory | keep |
| See You Space Cowboy | +1 Buffer at combat start | keep (BufferPower exists) |
| Swordfish II (boss) | +1 Energy, +2 Flow at combat start | keep |

## Powers (models to implement)

- FlowPower (stacking, persistent, no decay) — `CustomPowerModel`
- CarryThatWeightPower (lose 8 HP at start of next turn, then removes itself) — `CustomTemporaryPowerModel`
- JupiterJazzPower, TankPower, SpaceLionPower, BluePower, EggAndYou cut (STS1 power existed
  but its card was never pooled — stays cut unless a slot opens)

## Localization

- eng first; zhs wave ports the STS1 zh text (folder `localization/zhs/`, flat dotted keys).
- zh keyword rendering: STS2/Godot text server handles CJK properly (unlike STS1's libgdx
  renderer) — expect 势/入流 to color correctly; verify in-game during the zhs wave.

## Out of scope (this phase)

Custom combat rig beyond static sprite; char-select bg scene (gun smoke — queued for
MegaDot art pass); events; potions (STS2 potion pool gets vanilla potions by default);
Workshop publish.

## Open questions for user review

1. "In the Flow" threshold: 3 Flow (as patched in STS1) — confirm.
2. zh keyword name: `入流`? or keep raw `势` phrasing per card?
3. Starting deck: 2× Jeet Kune Do (new) vs STS1's 1× — confirm.
4. New rare name: "You're Gonna Carry That Weight" vs just "Carry That Weight".
