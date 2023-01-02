# ExiledUtils-Remake
Remake of one of my first plugins

This plugin adds some features to SCPSL (all configurable) & Fixes the Tutorial position when changing the role (configurable via config)

PRO TIP: My plugin dont break servers with the infinite things

# Incompatible Plugins
- CommonUtilities Because of the ScpVoiceChat Patch

# Config
- FixTutorialPosition: true (Default)
- HideTags: false (Default)
- InfiniteRadio: true (Default)
- InfiniteAmmo: false (Default)
- InfiniteMicroHID: false (Default)
- AddingTarget096Hint: Empty (Default)
- AddingTargetHintDuration: 5 (Default)
- AddingTargetHint: Empty (Default)
- CoinAHPGained: 10 (Default)
- CoinHint: +10AHP (Default)
- CoinHintDuration: 5 (Default)
- EnableEffectMovementBoost: true (Default)
- EffectDuration: 5 (Default)
- ReservedGroups: owner, admin, moderator, donator (Default)
- EnableLastPlayerText: true (Default)
- LastPlayerHintDuration: 10 (Default)
- LastPlayerHint: Empty (Default)
- Enable049BuffWhenReviving: true (Default)
- ScpVoiceChatRoles: RoleType List (By Default it Include all Scp Roles) - REMOVED TEMPORARILY

## Commands
- recall (~): Bring you all alive 0492 being 049
- jail (Required Permission: eu.jail) (RA): Jails a player (sets the targets role to tutorial and then it moves it to the tower) (Execute again in a jailed target to Unjail it)
- hidealltags (Aliase: hdat) (Required Permission: eu.hidealltags) (RA): Enable or Disable the HideTags configuration (If enabled, all tags will hide. `hidealltags`) (Execute it again: `hidealltags` to disable)
- modifyplayerahp (Aliase: mpahp) (Required Permission: eu.modifyplayerahp) (RA): Modify's a player AHP (arguments: mpahp <target> <amount>)
