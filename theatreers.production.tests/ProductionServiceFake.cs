using System.Collections.Generic;
using System.Linq;
using theatreers.shared.Models;
using theatreers.shared.Interfaces;

public class ProductionServiceFake : IProductionService
{
    private readonly List<ProductionModel> _ProductionList;
 
    public ProductionServiceFake()
    {
        _ProductionList = new List<ProductionModel>()
            {
                new ProductionModel() { Id = 1, Name = "ROS presents Anne" },
                new ProductionModel() { Id = 2, Name = "Sainsbury Singers presents Anything Goes" },
                new ProductionModel() { Id = 3, Name = "EBOS presents Singing in the Rain!" }
            };
    }
 
    public IEnumerable<ProductionModel> GetAll()
    {
        return _ProductionList;
    }
    
    public ProductionModel GetById(int id)
    {
        return _ProductionList.Where(a => a.Id == id)
            .FirstOrDefault();
    }
 
    public ProductionModel Create(ProductionModel newItem)
    {
        newItem.Id = _ProductionList.Count + 1;
        _ProductionList.Add(newItem);
        return newItem;
    }

    public ProductionModel Update(ProductionModel body)
    {
        var existing = _ProductionList.First(a => a.Id == body.Id);
        return existing;
    }
 
    public void Delete(int id)
    {
        var existing = _ProductionList.First(a => a.Id == id);
        _ProductionList.Remove(existing);
    }
}