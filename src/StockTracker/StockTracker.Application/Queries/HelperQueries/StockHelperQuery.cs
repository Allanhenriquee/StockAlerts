using System.Linq.Expressions;
using StockTracker.Domain.Models.Entities;

namespace StockTracker.Application.Queries.HelperQueries;

public static class StockHelperQuery
{
    public static Expression<Func<Stock, bool>> GetAllActive()
    {
        return u => u.Active == true;
    }
    
    public static Expression<Func<Stock,bool> >GetAllInactive()
    {
        return u => u.Active == false;
    }
}