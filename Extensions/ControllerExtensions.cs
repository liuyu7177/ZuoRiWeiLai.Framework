using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZuoRiWeiLai.Framework.Extensions
{
    public static partial class ControllerExtensions
    {
        public static bool ValidateModelExtensions(this Controller controller, object model)
        {
            return ValidateModelExtensions(controller, model, null);
        }

        private static bool ValidateModelExtensions(this Controller controller, object model, string prefix = null)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            if (model is IEnumerable)
            {
                foreach (var item in model as IEnumerable)
                {
                    ValidateModelBase(controller, item, prefix);
                }
            }
            else
            {

                ValidateModelBase(controller, model, prefix);
            }
            return controller.ModelState.IsValid;
        }

        private static void ValidateModelBase(Controller controller, object model, string prefix)
        {
            ModelMetadata metadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType());

            foreach (ModelValidationResult validationResult in ModelValidator.GetModelValidator(metadata, controller.ControllerContext).Validate(null))
            {
                controller.ModelState.AddModelError(CreateSubPropertyName(prefix, validationResult.MemberName), validationResult.Message);
            }
        }



        private static string CreateSubPropertyName(string prefix, string propertyName)
        {
            if (String.IsNullOrEmpty(prefix))
            {
                return propertyName;
            }
            else if (String.IsNullOrEmpty(propertyName))
            {
                return prefix;
            }
            else
            {
                return prefix + "." + propertyName;
            }
        }
    }
}
