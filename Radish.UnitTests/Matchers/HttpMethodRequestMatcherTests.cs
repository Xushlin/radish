using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Radish.Matchers;

namespace Radish.UnitTests.Matchers
{
    public class HttpMethodRequestMatcherTests
    {
        [Test]
        public void Match_when_http_method_is_equal_to_expected_should_return_true()
        {
            // Arrange
            var matcher = new HttpMethodRequestMatcher("post");
            var request = Substitute.For<IHttpRequest>();
            request.HttpMethod.Returns("post");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Match_when_http_method_is_ignore_case_equal_to_expected_should_return_true()
        {
            // Arrange
            var matcher = new HttpMethodRequestMatcher("post");
            var request = Substitute.For<IHttpRequest>();
            request.HttpMethod.Returns("POST");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Match_when_http_method_is_not_equal_to_expected_should_return_false()
        {
            // Arrange
            var matcher = new HttpMethodRequestMatcher("get");
            var request = Substitute.For<IHttpRequest>();
            request.HttpMethod.Returns("POST");

            // Act
            var result = matcher.Match(request);

            // Assert
            result.Should().BeFalse();
        }
    }
}
