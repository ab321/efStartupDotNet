using Core.Entities;
using Persistence;

namespace ApplicationDbContextTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Create1Cars_AddToContext_Persist()
    {
        using var target = new ApplicationDbContext();
        using var transaction = target.Database.BeginTransaction(); //Damit bleibt nicht in die Db
        
        var car1 = new Car {Make = "Toyota", Model = "Prius +", VIN = "1234"};
        
        var tyre = new Tyre {Make = "Dunlop", Dimension = "195/65 R15", Type = "Summer"};

        car1.Tyres = new List<Tyre> { tyre };
        
        target.Add(car1);
        target.SaveChanges();
        
        Assert.IsTrue(car1.Id > 0);
        Assert.IsTrue(tyre.Id > 0);

        int carId = car1.Id;
        car1 = null;
        car1 = target.Cars.FirstOrDefault();
        Assert.IsNotNull(car1);
        Assert.AreEqual(carId, car1.Id);
    }

    [TestMethod]
    public void CreateAppDbContext_ObjectNotNull()
    {
        using var target = new ApplicationDbContext();
        Assert.IsNotNull(target);
    }
}