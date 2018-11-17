using System.Collections.Generic;
using System.Linq;
using theatreers.shared.Models;
using theatreers.shared.Interfaces;

public class ProductionServiceFake : IProductionService
{
    private readonly List<Production> _ProductionList;
 
    public ProductionServiceFake()
    {
        _ProductionList = new List<Production>()
            {
                new Production() { Id = 1, Name = "ROS presents Anne" },
                new Production() { Id = 2, Name = "Sainsbury Singers presents Anything Goes" },
                new Production() { Id = 3, Name = "EBOS presents Singing in the Rain!" }
            };
    }
 
    public IEnumerable<Production> GetAll()
    {
        return _ProductionList;
    }
    
    public Production GetById(int id)
    {
        return _ProductionList.Where(a => a.Id == id)
            .FirstOrDefault();
    }
 
    public Production Create(Production newItem)
    {
        newItem.Id = _ProductionList.Count + 1;
        _ProductionList.Add(newItem);
        return newItem;
    }

    public Production Update(Production body)
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