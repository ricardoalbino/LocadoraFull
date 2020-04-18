using Locadora.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Locadora.Domain.Models;
using Locadora.Infra.Context;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Locadora.Infra.Repository
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {

        public FilmeRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public  Task<IEnumerable<Filme>> ObterFilmeComUsuario()
        {
            throw new NotImplementedException();

            //return await _dataContext.Filmes.AsNoTracking()
            // .Include(f => f.Usuario).ToListAsync();

            //return await (from f in _dataContext.Filmes.AsNoTracking()
            //              join u in _dataContext.Usuarios on f.UsuarioID equals u.Id
            //              where (f.UsuarioID == u.Id)
            //              select new Filme
            //              {

            //                  Nome = f.Nome,
            //                  Genero = f.Genero,
            //                  DataLançamento = f.DataLançamento,
            //                  ValorLocacao = f.ValorLocacao


            //              }).ToListAsync();
        }

        public async Task<IEnumerable<Filme>> ObterFilmePorDataDeLancamento(DateTime data)
        {
            return await _dataContext.Filmes.AsNoTracking()
             .Where(f => f.DataLançamento == data).ToListAsync();
        }

        public async  Task<IEnumerable<Filme>> ObterFilmePorGenero(string genero, DateTime? dataLançamento)
        {
            return await _dataContext.Filmes.AsNoTracking()
              .Where(f => f.Genero == genero ||  f.DataLançamento ==  dataLançamento ).ToListAsync();
        }

        //    public async Task<IEnumerable<Filme>> ObterFilmePorGenero(string genero)
        //    {
        //        return await _dataContext.Filmes.AsNoTracking()
        //        .Where(f => f.Genero == genero ).ToListAsync();
        //    }
        //}
    }
}
