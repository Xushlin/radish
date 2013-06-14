using System;
using Radish.Extractors;
using Radish.Matchers;
using Radish.Resources;

namespace Radish
{
    public class RequestSetting : ResponseSetting
    {
        protected IRequestMatcher _matcher;
        protected IResource resource;
        protected Func<IRequestMatcher> matcherFactoryMethod;

        public ResponseSetting Response
        {
            get
            {
                _matcher = matcherFactoryMethod();
                return this;
            }
        }
    }

    public class RequestMatcherSetting : RequestExtractorSetting
    {


        public bool IsMatch(IHttpRequest request)
        {
            return _matcher.Match(request);
        }

        public RequestExtractorSetting By
        {
            get
            {
                matcherFactoryMethod = () => new EqualRequestMatcher(MakeExtractor(), resource);
                return this;
            }
        }
    }

    public abstract class RequestExtractorSetting : RequestSetting
    {
        protected IRequestExtractor MakeExtractor()
        {
            if (resource.Type == ResourceType.Uri)
                return new UriRequestExtractor();

            return null;
        }

        public RequestExtractorSetting Uri(string uri)
        {
            resource = new UriResource(uri);
            return this;
        }
    }

    public class Setting : RequestMatcherSetting
    {

    }





    public abstract class ResponseSetting
    {
        protected IHttpHandler _handler;

        public void Text(string text)
        {
            Response(new TextContent(text));
        }

        private void Response(Content content)
        {
            _handler = new ContentHandler(content);
        }

        private void Response(IHttpHandler handler)
        {
            _handler = handler;
        }

        public void Handle(IHttpContext context)
        {
            _handler.Handle(context);
        }
    }

    public class ContentHandler : IHttpHandler
    {
        private readonly Content _content;

        public ContentHandler(Content content)
        {
            _content = content;
        }

        public void Handle(IHttpContext context)
        {
            var buffer = _content.GetContent();
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }
    }
}
