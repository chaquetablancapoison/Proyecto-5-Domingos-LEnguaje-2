//alquiler de vehiculos
using proyecto5.Models;
using proyecto5.Services;
using Spectre.Console;

AutoService autoService = new();

string[] options = [
"1.  Agregar Vehiculo",
"2. Eliminar Vehiculo",
"3. Lista de Vehiculos",
"4. Salir"    
];


while (true)
{
    var selections = new SelectionPrompt<string>()
    .Title("Indica la opcion a seleccionar:")
    .HighlightStyle(Color.GreenYellow)
    .AddChoices(options)
    .WrapAround();

    var option = AnsiConsole.Prompt(selections);
    Console.WriteLine(option);

    List<Auto> autos = autoService.FindAll();
    
    switch (option)
    {
        case "1.  Agregar Vehiculo":
         AnsiConsole.Clear();

         var marca = AnsiConsole.Ask<string>("[Gold3]Ingrese el modelo del vehiculo:[/]");
         var description = AnsiConsole.Ask<string>("[Gold3]Ingrese la descripcion del vehiculo:[/]");

         var Ids = autos.Max(auto => auto.Id);

         var newAuto = new Auto
         {
            Id = Ids + 1,
            Marca = marca,
            Description = description  
         };

         autoService.Create(newAuto);
         AnsiConsole.Clear();
         AnsiConsole.MarkupLine("\n[Green]Auto agregado[/]");



        break;
        case "2. Eliminar Vehiculo":
        AnsiConsole.Clear();
        var id = AnsiConsole.Ask<int>("\n[Gold3]Indica el id del vehiculo que deseas eliminar:[/]");
        AnsiConsole.WriteLine("");

        var confirm = AnsiConsole.Confirm("ESTAS SEGURO QUE DESEAS ELIMINARLO?:");

        if (confirm)
            {
              var deleted = autoService.Delete(id);

              if (deleted)
                {
                 AnsiConsole.MarkupLine("\n[Green]Vehiculo eliminado![/]");
                 break; }
                 AnsiConsole.MarkupLine("\n[Green]Vehiculo no encontrado![/]\n");
                 break;
            }
            AnsiConsole.MarkupLine("\n[Green]Operacion cancelada[/]\n");
        break;
        case "3. Lista de Vehiculos":
        AnsiConsole.Clear();
        
        var table = new Table()
        .Title("Lista de Vehiculos")
        .BorderColor(Color.Green)
        .RoundedBorder();
        
        table.AddColumn("Id");
        table.AddColumn("Marca");
        table.AddColumn("Descripcion");
 
        foreach (var Auto in autos) {
        table.AddRow(Auto.Id.ToString(), Auto.Marca, Auto.Description);
      }

      AnsiConsole.Write(table);
      break;
      case "4. Salir":
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Fin de la aplicacion.[/]");

       return; 
       






    }

}
