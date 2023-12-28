using CarApp.Core.Dto;
using CarApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Core.ServiceInterface
{
    public interface ICarAppServices
    {
        Task<CarsApp> GetAsync(Guid id);
        Task<CarsApp> Create(CarAppDto dto);
        Task<CarsApp> Delete(Guid id);
        Task<CarsApp> Update(CarAppDto dto);
    }


}

