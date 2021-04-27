using Characteristics;

namespace BuffSystem.BuffInterface
{
    public interface IUpdatableBuff : IBuff
    {
        void UpdateBuff(PersonCharacteristics personCharacteristics);
    }
}