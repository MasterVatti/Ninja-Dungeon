using Characteristics;

namespace BuffSystem.BuffInterface
{
    public interface IUpdatableBuff : IPassiveBuff
    {
        void UpdateBuff(PersonCharacteristics personCharacteristics);
    }
}