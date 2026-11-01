using proyecto5.Models;

namespace proyecto5.Services;


public class AutoService
{
    //Simula la base de datos segun el github del profe
    private readonly List<Auto> _autos = [
        new Auto{
            Id = 1,
            Marca = "Toyota supra",
            Description = "Perfecto para Pantallar"
        },
        new Auto{
            Id = 2,
            Marca = "Toyota tacoma",
            Description = "Perfecta para salir de camping"

        },
        new Auto{
            Id = 3,
            Marca = "Toyota camry",
            Description = "Perfecto para salir por la city"
        }


    ];

    public List<Auto> FindAll()
    {
        foreach (var auto in _autos)
        {
            Console.WriteLine(auto.Marca);
        }
      return _autos;
    }
    public void Create(Auto auto)
    {
        _autos.Add(auto);
    }
   public bool Delete(int id)
    {
        var auto = _autos.FirstOrDefault(b => b.Id == id);

        if (auto is null)
        {
            return false;
        }

        _autos.Remove(auto);
        return true;
    }
}