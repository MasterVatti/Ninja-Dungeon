using Characteristics;

namespace BuffSystem.BuffInterface
{
    public interface IBuff
    {
        void StartBuff(PersonCharacteristics personCharacteristics);
        void StopBuff(PersonCharacteristics personCharacteristics);
    }
}