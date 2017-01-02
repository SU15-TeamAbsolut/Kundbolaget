# Enums

## OrderStatus
 - `Creating` -- ordern håller på att manuellt skapas men är inte registrerad än
 - `Registered` -- ordern är registrerad och redo för vidare behandling (standard-status för en inläst kundorderfil)
 - `Processing` -- ordern håller på att behandlas (plockas, packas)
 - `ReadyToShip` -- ordern är packad och redo att levereras
 - `Shipping` -- ordern är ute för leverans
 - `Delivered` -- ordern är mottagen av kunden
 - `Cancelled` -- ordern är makulerad

När ordern är `Registered` eller `Processing` betraktas antalet beställda artiklar som reserverade och ej tillgängliga för andra ordrar -- reserverade artiklar ska ej ingå i lagersaldot.
