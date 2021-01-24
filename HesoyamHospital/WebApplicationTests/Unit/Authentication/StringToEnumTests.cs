using System.Collections.Generic;
using Xunit;
using Shouldly;
using Authentication.Model;
using Authentication.Mappers;

namespace WebApplicationTests.Unit.Authentication
{
    public class StringToEnumTests
    {
        [Theory]
        [MemberData(nameof(GenderData))]
        public void String_to_gender(string gender, Sex value)
        {
            Sex sex = NewPatientMapper.GenderToEnum(gender);

            sex.ShouldBe(value);
        }

        [Theory]
        [MemberData(nameof(BloodTypeData))]
        public void String_to_blood_type(string blood, BloodType value)
        {
            BloodType bloodType = NewPatientMapper.BloodTypeToEnum(blood);

            bloodType.ShouldBe(value);
        }

        public static IEnumerable<object[]> GenderData =>
        new List<object[]>
        {
            new object[] { "MALE", Sex.MALE },
            new object[] { "0", Sex.MALE },
            new object[] { "male", Sex.OTHER },
            new object[] { "9", Sex.OTHER },
        };

        public static IEnumerable<object[]> BloodTypeData =>
        new List<object[]>
        {
            new object[] { "A_POSITIVE", BloodType.A_POSITIVE },
            new object[] { "1", BloodType.A_NEGATIVE },
            new object[] { "a_positive", BloodType.NOT_TESTED },
            new object[] { "20", BloodType.NOT_TESTED },
        };

    }
}
