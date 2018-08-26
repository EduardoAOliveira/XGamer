using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XGame.Domain.Interfaces.Repositories.Base
{
    /// <summary>
    /// Interface para repositorio base de uma entidade/class com opção de passar o ID. Possui todos os metodos necessarios para o Crud e alguns identificados posteriormente.
    /// </summary>
    /// <typeparam name="TEntidade"> Classe/Entidade </typeparam>
    /// <typeparam name="TId"> ID da entidade</typeparam>
    public interface IRepositoryBase<TEntidade, TId>
           where TEntidade : class
           where TId : struct
    {
        // Listar qualquer coisa de uma classe/entidade utilizando espressão lambda. Inclui opção de adcionar entidades associdas a classe.
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);

        void Remover(TEntidade entidade);

        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades);
    }
}
