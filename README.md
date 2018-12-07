# Battleships

Commands:

* StartGame
  * gameType: enum { singlePlayer, multiPlayer }
  * @return: Guid

* AddPlayer
  * gameId: Guid
  * @return: Guid

* AddBattleship
  * playerId: Guid
  * coordinates: coordinate[]
  * @return: Guid

* Attack
  * playerId: Guid
  * coordinate: coordinate { x: int, y: int }
  * @return: Guid


Domain Events

* GameStarted
  * gameId: Guid

* PlayerAdded
* playerId: Guid

* BattleshipAdded
  * battleshipId: Guid
  * playerId: Guid
  * coordinates: battleshipCoordinate[] { coordinate: coordinate, hit: boolean }

* BattleshipAttacked
  * battleshipId: Guid
  * coordinate: coordinate

* GameEnded
  * gameId: Guid


Queries:

* GetAttackResult
  * attackId: Guid
  * @return: attackResult { attackId: guid, hit: boolean }

* GetUsedCoordinates
  * @return: coordinate[]

* IsGameLost
  * gameId: Guid
  * @return: boolean

