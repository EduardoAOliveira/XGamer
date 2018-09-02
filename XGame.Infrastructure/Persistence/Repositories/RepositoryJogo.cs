using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infrastructure.Persistence.Map;
using System.Data.Entity;
using XGame.Infrastructure.Persistence.Repositories.Base;

namespace XGame.Infrastructure.Persistence.Repositories
{
    public class RepositoryJogo : RepositoryBase<Jogo,Guid>, IRepositoryJogo
    {
        protected readonly XGameContext _context;

        public RepositoryJogo(XGameContext context) : base(context)
        {
            _context = context;
        }

    }
}
