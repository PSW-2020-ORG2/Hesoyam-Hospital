using System.Collections.Generic;

namespace ActionsAndBenefits.Repository.Abstract
{
    public interface IIdGeneratorStrategy<T, ID>
    {
        ID GetMaxId(IEnumerable<T> entities);
    }
}
