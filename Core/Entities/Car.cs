namespace Core.Entities;

public class Car : BaseEntitiy
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string VIN { get; set; }

    public ICollection<Tyre> Tyres { get; set; }
    
}