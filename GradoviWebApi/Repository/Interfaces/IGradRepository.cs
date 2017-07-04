using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradoviWebApi.Models;

namespace GradoviWebApi.Repository.Interfaces
{
    public interface IGradRepository
    {
        IEnumerable<Grad> GetAll();
        IEnumerable<Grad> GetAllFiltered(int populacijaOd, int populacijaDo);
        Grad GetById(int id);
        void Add(Grad grad);
        void Update(Grad grad);
        void Delete(Grad grad);
    }
}
