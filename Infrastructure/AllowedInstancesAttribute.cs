using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EPiServer;
using EPiServer.Core;
using EPiServer.Validation;


namespace JaxonFoundation.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AllowedInstancesAttribute : Attribute
    {
        public AllowedInstancesAttribute(int maxInstances)
        {
            MaxInstances = maxInstances;
        }

        public enum InstanceScope
        {
            Site,
            SameParent,
            SameParentOrDescendant
        }

        public int MaxInstances { get; set; }
        public InstanceScope Scope { get; set; }
    }

    public class AllowedInstancesValidator : IValidate<PageData>
    {
        private readonly IContentLoader contentLoader;

        public AllowedInstancesValidator(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public IEnumerable<ValidationError> Validate(PageData instance)
        {
            var allowedInstanceAttribute = instance.GetType().GetCustomAttribute<AllowedInstancesAttribute>(true);

            if (allowedInstanceAttribute == null)
            {
                return Enumerable.Empty<ValidationError>();
            }

            var searchRoot = allowedInstanceAttribute.Scope == AllowedInstancesAttribute.InstanceScope.Site
                                    ? ContentReference.StartPage
                                    : instance.ParentLink;

            var instancesOfType = this.GetInstancesOfType(instance.GetType(), searchRoot, allowedInstanceAttribute.Scope);

            if (instance.IsPendingPublish)
            {
                instancesOfType++;
            }

            if (instancesOfType > allowedInstanceAttribute.MaxInstances)
            {
                return new[]
                {
                new ValidationError()
                    {
                        ErrorMessage = string.Format("Only {0} instances of this page type can exist at this level", allowedInstanceAttribute.MaxInstances),
                        PropertyName = "PageName",
                        Severity = ValidationErrorSeverity.Error,
                        ValidationType = ValidationErrorType.StorageValidation
                    }
            };
            }

            return Enumerable.Empty<ValidationError>();
        }

        private int GetInstancesOfType(Type type, ContentReference rootPage, AllowedInstancesAttribute.InstanceScope instanceScope)
        {
            var instances = 0;
            var children = contentLoader.GetChildren<IContent>(rootPage, new LoaderOptions());

            foreach (var child in children)
            {
                if (type == child.GetType())
                {
                    instances++;
                }

                if (instanceScope == AllowedInstancesAttribute.InstanceScope.SameParent)
                {
                    continue;
                }

                instances += this.GetInstancesOfType(type, child.ContentLink, instanceScope);
            }

            return instances;
        }
    }
}
