using DapperBase.Models;
using System.Collections.Generic;
namespace DapperBase.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}
