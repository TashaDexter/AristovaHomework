using System;

namespace Equivalence
{
    public class Person
    {
        public int PassportID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

        public override int GetHashCode()
        {
            return ShiftAndWrap(PassportID.GetHashCode(), 2) ^ FirstName.GetHashCode() + ShiftAndWrap(LastName.GetHashCode(), 2)^DateOfBirth.GetHashCode()^PlaceOfBirth.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Person))
                return false;
            var person = (Person)obj;
            return person.PassportID == PassportID
                && person.FirstName==FirstName
                && person.LastName==LastName
                && person.DateOfBirth==DateOfBirth
                && person.PlaceOfBirth==PlaceOfBirth;
        }


        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            uint wrapped = number >> (32 - positions);
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        //Для того, чтобы при сравнении через оператор == вызвался переопределённый метод Equals
        //необходимо перегрузить операторы отношения == и !=
        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

    }
}
