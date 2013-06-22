using System.Collections.Specialized;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class ExpressionRequestMatcherTests
    {
        [Test]
        public void Match_when_matched_expression_should_return_true()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.Headers.Returns(new NameValueCollection()
                {
                    {"head","test"}
                });
            var matcher = new ExpressionRequestMatcher(x => x.Headers["head"] == "test");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeTrue();
        }


        [Test]
        public void Match_when_unmatched_expression_should_return_false()
        {
            // Arrange
            var request = Substitute.For<IHttpRequest>();
            request.Headers.Returns(new NameValueCollection()
                {
                    {"head","invalid"}
                });
            var matcher = new ExpressionRequestMatcher(x => x.Headers["head"] == "test");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeFalse();
        }
    }
}
