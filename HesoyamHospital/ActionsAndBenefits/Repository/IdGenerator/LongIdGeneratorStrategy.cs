using System.Collections.Generic;
using System.Linq;

namespace ActionsAndBenefits.Repository.Abstract
{
    class LongIdGeneratorStrategy<T> : IIdGeneratorStrategy<T, long>
        where T : IIdentifiable<long>
    {
        public long GetMaxId(IEnumerable<T> entities)
        => entities.Any() ? 0 : entities.Max(entity => entity.GetId());
    }
}
