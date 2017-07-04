using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradoviWebApi.Models;

namespace GradoviWebApi.Repository.Interfaces
{
    public interface IDrzavaRepository
    {
        IEnumerable<Drzava> GetAll();
        Drzava GetById(int id);
        IEnumerable<DrzavaDTO> GetPopulation();
        void Add(Drzava drzava);
        void Update(Drzava drzava);
        void Delete(Drzava drzava);
    }
}
