namespace ActionsAndBenefits.Repository.Abstract
{
    public interface ISequencer<T>
    {
        void Initialize(T initID);

        T GenerateID();

    }
}