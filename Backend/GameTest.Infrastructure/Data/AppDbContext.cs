using GameTest.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GameTest.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {

    }
}
