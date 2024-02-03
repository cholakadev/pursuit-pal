using FluentAssertions;
using NetArchTest.Rules;

namespace PusuitPal.Architecture.Tests.Extensions
{
    internal static class ConditionListExtensions
    {
        internal static void AssertIsSuccessful(this ConditionList conditionList)
        {
            var result = conditionList.GetResult();
            (result.FailingTypeNames ?? Array.Empty<string>()).Should().HaveCount(0);
        }
    }
}
