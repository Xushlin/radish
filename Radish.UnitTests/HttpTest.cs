using FluentAssertions;
using NUnit.Framework;

namespace Radish.UnitTests
{
    public class HttpTest
    {
        [Test]
        public void Get()
        {
            // Arrange
            var url = "http://www.baidu.com";

            // Act
            ResponseResult result = Http.Get(url);

            // Assert
            result.GetContent().Should().NotBeNull();
        }


//        [Test]
//        public void Put()
//        {
//            //            dev.onlineacademy.se/api 
//            // Arrange
//            var url = "http://dev.onlineacademy.se/api/user/addorupdate/";
//            //            var url = "http://dev.onlineacademy.se/api/user/view";
//
//            var data = "email=xusl@shinetechchina.com&password=123&firstname=xu&lastname=shilin&company=shinetechchina&city=xian&phone=18723232323";
//            //            var data = "username=previa@onlineacademy.se";
//            // Act
//            var result = Http.Put(url, data);
//        }
//
//        [Test]
//        public void Post()
//        {
//            // Arrange
//            var url = "http://dev.onlineacademy.se/api/user/view";
//            //            var data = "username=previa@onlineacademy.se";
//            var data = "userid=835";
//            // Act
//            var result = Http.Post(url, data);
//        }
    }
}
