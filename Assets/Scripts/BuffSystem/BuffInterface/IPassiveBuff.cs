using Characteristics;

namespace BuffSystem.BuffInterface
{
    public interface IPassiveBuff : IBuff
    {
        void StopBuff(PersonCharacteristics personCharacteristics);
    }
}