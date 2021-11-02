using ContextService.Interfaces;

namespace ContextService.GraphQL
{
    public class Mutations
    {
        private readonly ICtxRepository _ctxRepository;
        private readonly ILupRepository _lupRepository;
        
        public Mutations(
            ICtxRepository ctxRepository, 
            ILupRepository lupRepository
        )
        {
            _lupRepository = lupRepository;
            _ctxRepository = ctxRepository;
        }
        
        
    }
}