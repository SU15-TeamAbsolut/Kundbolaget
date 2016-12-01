# Guider

## Skapande av nya modeller

### Domänklassen
Skapa en ny klass med modellens namn i `Models/EntityModels/`, tex `Supplier.cs`.
Klassen behöver inte ärva något. Se [Data Annotations] för dokumentation om
attribut.

[Data Annotations]:http://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx

``` csharp
public class Supplier
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}
```

### Databasmigration
Efter att domänklassen är skapad kan Entity Framework utifrån detta upptäcka
skillnader i databasen och skapa en migrationsfil från detta. I Package Manager
Console, använd `Add-Migration` för att skapa en migration med relevant namn:

``` powershell
Add-Migration CreateSupplierModel
```

Detta skapar en datum-markerad migrationsfil. Efter att ha verifierat att migrationen
utför korrekta ändringar, körs migrationen med `Update-Database` i konsollen.
